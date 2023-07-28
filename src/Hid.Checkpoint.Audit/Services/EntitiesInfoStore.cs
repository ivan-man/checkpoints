using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Hid.Checkpoint.Audit.Abstractions.Attributes;
using Hid.Checkpoint.Audit.Abstractions.Interfaces;
using Hid.Checkpoint.Audit.Abstractions.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Hid.Checkpoint.Audit.Services;

internal class EntitiesInfoStore : IEntitiesInfoStore
{
    private readonly ConcurrentDictionary<Type, TrackingInfo> _store = new();

    public bool ShouldBeTracked(Type entityType, string propertyName)
    {
        return _store.TryGetValue(entityType, out var record)
               && record.PropertyInfos.Any(e => e.PropertyInfo.Name == propertyName);
    }

    public bool ShouldBeTracked(Type entityType)
    {
        return _store.TryGetValue(entityType, out var record) && record.IsTracked;
    }

    public AuditPropertyInfo[] GetPropertyInfos(Type entityType)
    {
        return _store.TryGetValue(entityType, out var record)
            ? record.PropertyInfos
            : Enumerable.Empty<AuditPropertyInfo>().ToArray();
    }

    public bool ShouldBeTracked(object? entityEntry)
    {
        if (entityEntry is null)
            return false;

        var type = entityEntry is EntityEntry entry ? entry.Entity.GetType() : entityEntry.GetType();

        if (_store.TryGetValue(type, out var record))
        {
            return record.IsTracked;
        }

        if (type.GetCustomAttribute<AuditedEntityAttribute>() is not { })
        {
            _store.TryAdd(type, new TrackingInfo(false));
            return false;
        }

        AuditPropertyInfo[] auditPropertyInfos;
        
        var propertyInfos = type.GetProperties(IEntitiesInfoStore.BFlags);

        if (propertyInfos.Any(p => p.GetCustomAttribute<AuditedMemberAttribute>() != null))
        {
            auditPropertyInfos = propertyInfos.Where(e =>
                    e.GetCustomAttribute<AuditedMemberAttribute>() != null
                    && (e.PropertyType.IsPrimitive
                        || e.PropertyType.IsValueType
                        || e.PropertyType == typeof(string)
                        || e.PropertyType == typeof(DateTime)
                        || e.PropertyType == typeof(TimeOnly)
                        || e.PropertyType == typeof(DateOnly)))
                .Select(q => new AuditPropertyInfo(q)
                {
                    DisplayName = q.GetCustomAttribute<DisplayAttribute>()?.Name,
                })
                .ToArray();
        }
        else
        {
            auditPropertyInfos = propertyInfos.Where(e =>
                    e.GetCustomAttribute<AuditIgnoreAttribute>() == null
                    && (e.PropertyType.IsPrimitive
                        || e.PropertyType.IsValueType
                        || e.PropertyType == typeof(string)
                        || e.PropertyType == typeof(DateTime)
                        || e.PropertyType == typeof(TimeOnly)
                        || e.PropertyType == typeof(DateOnly)))
                .Select(q => new AuditPropertyInfo(q)
                {
                    DisplayName = q.GetCustomAttribute<DisplayAttribute>()?.Name,
                })
                .ToArray();
        }

        _store.TryAdd(
            type,
            new TrackingInfo(true)
            {
                PropertyInfos = auditPropertyInfos, FullTypeName = type.AssemblyQualifiedName
            });

        return true;
    }
}
