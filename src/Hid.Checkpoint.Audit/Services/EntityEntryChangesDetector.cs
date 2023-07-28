using System.Diagnostics;
using Hid.Checkpoint.Audit.Abstractions.Enums;
using Hid.Checkpoint.Audit.Abstractions.Interfaces;
using Hid.Checkpoint.Audit.Abstractions.Models;
using Hid.Checkpoint.Audit.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Hid.Checkpoint.Audit.Services;

internal class EntityEntryChangesDetector : IChangesDetector
{
    private readonly IEntitiesInfoStore _infoStore;
    private readonly IStorageService _storageService;
    private readonly ILogger<EntityEntryChangesDetector> _logger;

    public EntityEntryChangesDetector(
        IEntitiesInfoStore infoStore, 
        IStorageService storageService, 
        ILogger<EntityEntryChangesDetector> logger)
    {
        _infoStore = infoStore;
        _storageService = storageService;
        _logger = logger;
    }

    /// <inheritdoc cref="IEntitiesInfoStore.ShouldBeTracked(object)"/>
    public bool ShouldBeTracked(object e)
    {
        return _infoStore.ShouldBeTracked(e);
    }

    /// <inheritdoc cref="IEntitiesInfoStore.ShouldBeTracked(Type, string)"/>
    public bool MemberShouldBeTracked(Type t, string propertyName)
    {
        return _infoStore.ShouldBeTracked(t, propertyName);
    }

    public async Task ReceiveChanges(
        SaveChangesCompletedEventData eventData,
        Type entryType,
        EntityState changeType,
        EntityEntry changedState,
        object originalState)
    {
        if (_infoStore.ShouldBeTracked(entryType))
            await ReceiveAuditChanges(eventData, entryType, changeType, changedState, originalState);
    }

    private async Task ReceiveAuditChanges(
        DbContextEventData eventData,
        Type entryType,
        EntityState changeType,
        EntityEntry changedState,
        object originalState)
    {
        var entityChanges = PresetAuditChanges(entryType);

        var keyName = changedState.Metadata
            .FindPrimaryKey()
            ?.Properties
            .Select(x => x.Name)
            .First();

        if (string.IsNullOrWhiteSpace(keyName))
            return;

        entityChanges.EntityId = changedState.Entity
            .GetType()
            .GetProperty(keyName)
            ?.GetValue(changedState.Entity, null)
            ?.ToString() ?? "N/A";

        entityChanges.ChangesType = changeType.FromEntryState();

        var tasks = new List<Task>();

        try
        {
            var memberChanges = new List<AuditMemberEvent>();

            eventData.Context?.ChangeTracker.TrackGraph(changedState.Entity, changeType, node =>
            {
                memberChanges = DetectMembersChanges(entryType, originalState, node.Entry.Entity);
                return node.NodeState is EntityState.Unchanged or EntityState.Detached;
            });

            entityChanges.MembersEvents = memberChanges;
            
            tasks.Add(_storageService.AddAsync(entityChanges));
        }
        finally
        {
            if (tasks.Any())
                await Task.WhenAll(tasks);
        }
    }

    private AuditEntityEvent PresetAuditChanges(
        Type entityType,
        string employeeIdField = "Employee.id",
        string profileIdField = "profile.id",
        string userInfoField = "user.info",
        string roleField = "role.id"
    )
    {
        var result = new AuditEntityEvent
        {
            EntityType = entityType.Name,
            EntityFullType = entityType.AssemblyQualifiedName
        };

        var activity = Activity.Current;

        if (activity == null)
            return result;

        var personIdStr = activity.Baggage.LastOrDefault(e => e.Key == employeeIdField).Value;
        if (int.TryParse(personIdStr, out var personId))
        {
            result.PersonId = personId;
        }

        var userInfo = activity.Baggage.LastOrDefault(e => e.Key == userInfoField).Value;
        result.UserInfo = userInfo;

        var profileId = activity.Baggage.LastOrDefault(e => e.Key == profileIdField).Value;
        if (int.TryParse(profileId, out var userId))
            result.ProfileId = userId;

        var roleId = activity.Baggage.LastOrDefault(e => e.Key == roleField).Value;
        if (int.TryParse(profileId, out var role))
        {
            result.InitiatorType = role switch 
            {
                1 => ChangesInitiatorType.Administrator,
                2 => ChangesInitiatorType.User,
                3 => ChangesInitiatorType.User,
                4 => ChangesInitiatorType.User,
                5 => ChangesInitiatorType.User,
                _ => ChangesInitiatorType.System,
            };
        }

        return result;
    }
    
    private List<AuditMemberEvent> DetectMembersChanges(
        Type entityType,
        object baseEntity, 
        object changedEntity) 
    {
        var propertyInfos = _infoStore.GetPropertyInfos(entityType);

        var result = new List<AuditMemberEvent>();
        foreach (var propertyInfo in propertyInfos)
        {
            var originalValue = baseEntity != null ? propertyInfo.PropertyInfo.GetValue(baseEntity) : null;
            var changedValue = propertyInfo.PropertyInfo.GetValue(changedEntity);
            
            var sOrigin = JsonConvert.SerializeObject(originalValue);
            var sChanged = JsonConvert.SerializeObject(changedValue);

            if (sChanged.Equals(sOrigin)) continue;
            
            var e = new AuditMemberEvent
            {
                DisplayName = propertyInfo.DisplayName,
                OldValue = sOrigin,
                NewValue = sChanged,
                PropertyName = propertyInfo.PropertyInfo.Name,
            };
                
            result.Add(e);
        }

        return result;
    }
}
