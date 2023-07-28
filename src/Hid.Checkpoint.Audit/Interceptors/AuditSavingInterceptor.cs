using System.Collections.Concurrent;
using Hid.Checkpoint.Audit.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Hid.Checkpoint.Audit.Interceptors;

internal class AuditSavingInterceptor : SaveChangesInterceptor
{
    private readonly IChangesDetector _changesDetector;
    private readonly ILogger<AuditSavingInterceptor> _logger;
    
    private readonly ConcurrentQueue<(Type entryType, EntityState changesType, EntityEntry entry, object baseState)>
        _entriesQueue = new();

    public AuditSavingInterceptor(IChangesDetector changesDetector,  ILogger<AuditSavingInterceptor> logger)
    {
        _changesDetector = changesDetector;
        _logger = logger;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var savingResult = SavingChangesAsync(eventData, result);
        if (savingResult.IsCompleted || savingResult.IsCanceled)
            return savingResult.Result;

        return savingResult.GetAwaiter().GetResult();
    }
    
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var baseResult = base.SavingChangesAsync(eventData, result, cancellationToken);

        var entities = GetEntries(eventData);
        if (!entities.Any())
            return await baseResult;

        foreach (var entity in entities)
        {
            var entry = entity.OriginalValues.ToObject();
            var entityType = entry.GetType();

            if (entity.State == EntityState.Added)
            {
                _entriesQueue.Enqueue((entityType, entity.State, entity, null)!);
                continue;
            }

            var originalData = ConstructOriginal(entity, entityType);
            _entriesQueue.Enqueue((entityType, entity.State, entity, originalData));
        }

        return await baseResult;
    }
    
    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        var savingResult = SavedChangesAsync(eventData, result);
        if (savingResult.IsCompleted || savingResult.IsCanceled)
            return savingResult.Result;

        return savingResult.GetAwaiter().GetResult();
    }

    public override async ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken cancellationToken = default)
    {
        while (_entriesQueue.TryDequeue(out var tuple))
        {
            var (entryType, changeType, baseEntity, original) = tuple;

            try
            {
                await _changesDetector.ReceiveChanges(eventData, entryType, changeType, baseEntity, original);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to receive changes for {type}", entryType.FullName);
            }
        }

        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }
    
    private List<EntityEntry> GetEntries(DbContextEventData eventData)
    {
        return eventData.Context?.ChangeTracker.Entries()
            .Where(e => e.State != EntityState.Unchanged
                        && e.State != EntityState.Detached
                        && _changesDetector.ShouldBeTracked(e))
            ?.ToList() ?? Enumerable.Empty<EntityEntry>().ToList();
    }    
    
    private object ConstructOriginal(EntityEntry entity, Type entityType)
    {
        var entry = entity.OriginalValues.ToObject();

        foreach (var member in entity.Members)
        {
            if (!_changesDetector.MemberShouldBeTracked(entityType, member.Metadata.Name))
                continue;

            switch (member)
            {
                case PropertyEntry:
                    continue;
                case ReferenceEntry reference:
                    ProcessReference(ref entry, reference);
                    continue;
                case CollectionEntry collection:
                    ProcessCollection(ref entry, collection);
                    continue;
            }
        }

        return entry;
    }

    private static void ProcessReference(ref object entity, ReferenceEntry reference)
    {
        var property = reference.TargetEntry?.OriginalValues.ToObject();
        if (property is null)
            return;

        entity.GetType().GetProperty(reference.Metadata.Name)?
            .SetValue(entity, property);
    }
    
    private void ProcessCollection(ref object entity, CollectionEntry collection)
    {
        try
        {
            var propName = collection.Metadata.Name;
            var items = collection.CurrentValue?.Cast<object>().ToList();

            if (items == null || items.Count == 0)
                return;

            Type? type = null;
            object? dataToSet = null;
            
            foreach (var item in items)
            {
                if (item == null)
                    continue;

                if (type == null)
                {
                    type = item.GetType();
                    var list = typeof(List<>);
                    var listOfType = list.MakeGenericType(type);
                    dataToSet = Activator.CreateInstance(listOfType);

                    if (dataToSet == null)
                        continue;
                }

                dataToSet!.GetType().GetMethod("Add")?
                    .Invoke(dataToSet, new[] { collection.FindEntry(item)?.OriginalValues.ToObject() });
            }

            entity.GetType().GetProperty(propName)?.SetValue(entity, dataToSet);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to get {MethodName}", nameof(ProcessCollection));
        }
    }
}
