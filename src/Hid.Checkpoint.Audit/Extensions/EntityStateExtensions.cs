using Hid.Checkpoint.Audit.Abstractions.Enums;
using Microsoft.EntityFrameworkCore;

namespace Hid.Checkpoint.Audit.Extensions;

public static class EntityStateExtensions
{
    internal static ChangesType FromEntryState(this EntityState state)
    {
        return state switch
        {
            EntityState.Detached => ChangesType.Unchanged,
            EntityState.Unchanged => ChangesType.Unchanged,
            EntityState.Deleted => ChangesType.Deleted,
            EntityState.Modified => ChangesType.Modified,
            EntityState.Added => ChangesType.Added,
            _ => ChangesType.Unchanged
        };
    }
    
    internal static bool IsNeedToSend(this EntityState state, EntityChangesTypes attributeRule)
    {
        return state switch
        {
            EntityState.Detached => false,
            EntityState.Unchanged => false,
            EntityState.Deleted => attributeRule.HasFlag(EntityChangesTypes.Deleted),
            EntityState.Modified => attributeRule.HasFlag(EntityChangesTypes.Modified),
            EntityState.Added => attributeRule.HasFlag(EntityChangesTypes.Added),
            _ => false
        };
    }
}
