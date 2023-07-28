using System.Collections.Immutable;
using Hid.Checkpoint.Common.Enums;

namespace Hid.Checkpoint.Common.Extensions;

public static class RoleFlagsExtensions
{
    public static ImmutableList<string> GetRoleNames(this RoleFlags? flags)
    {
        return flags.HasValue 
            ? GetRoleNames(flags.Value)
            : Enumerable.Empty<string>().ToImmutableList();
    }
    
    public static ImmutableList<string> GetRoleNames(this RoleFlags flags)
    {
        var result = new List<string>();
        
        foreach (var value in Enum.GetValues<RoleFlags>())
        {
            if(flags.HasFlag(value))
                result.Add(value.ToString());
        }

        return result.ToImmutableList();
    }
}
