using System.Collections.Concurrent;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Hid.Shared.Ef.Interceptors;

public class SaveDateTimeInterceptor : SaveChangesInterceptor
{
    private static readonly ConcurrentDictionary<Type, List<PropertyInfo>?> PropsCache = new();
    private static readonly object Sync = new();

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        => SavingChangesAsync(eventData, result).Result;

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var baseResult = base.SavingChangesAsync(eventData, result, cancellationToken);
        var entries = GetEntries(eventData);

        if (entries?.Any() != true)
            return await baseResult;

        foreach (var entry in entries)
        {
            var entityType = entry.Entity.GetType();

            var infos = GetPropertyRules(entityType);

            if (infos == null)
                continue;

            foreach (var info in infos)
            {
                var value = info.GetValue(entry.Entity);
                if (value == null)
                    continue;

                var valueDateTime = (DateTime)value;
                if (valueDateTime.Kind == DateTimeKind.Unspecified)
                    continue;

                valueDateTime = valueDateTime.ToUniversalTime();
                valueDateTime = DateTime.SpecifyKind(valueDateTime, DateTimeKind.Unspecified);
                info.SetValue(entry.Entity, valueDateTime);
            }
        }

        return await baseResult;
    }

    private static List<PropertyInfo>? GetPropertyRules(Type entityType)
    {
        if (PropsCache.TryGetValue(entityType, out var infos)) 
            return infos;
        
        lock (Sync)
        {
            if (PropsCache.TryGetValue(entityType, out infos))
                return infos;

            infos = new List<PropertyInfo>();

            foreach (var info in entityType.GetProperties())
            {
                var valType = info.PropertyType;
                if (valType == typeof(DateTime) || valType == typeof(DateTime?))
                    infos.Add(info);
            }

            if (infos.Count > 0)
            {
                infos.TrimExcess();
                PropsCache.TryAdd(entityType, infos);
            }
            else
            {
                infos = null;
                PropsCache.TryAdd(entityType, null);
            }
        }

        return infos;
    }


    private List<EntityEntry>? GetEntries(DbContextEventData eventData)
    {
        return eventData.Context?.ChangeTracker.Entries()
            .Where(e => e.State != EntityState.Unchanged
                        && e.State != EntityState.Detached)
            .ToList();
    }
}
