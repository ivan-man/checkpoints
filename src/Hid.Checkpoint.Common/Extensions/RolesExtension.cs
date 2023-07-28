using Hid.Checkpoint.Common.Enums;

namespace Hid.Checkpoint.Common.Extensions;

public static class RolesExtension
{
    public static List<RoleFlags> GetRolesList(this RoleFlags? input)
    {
        return !input.HasValue 
            ? Enumerable.Empty<RoleFlags>().ToList() 
            : GetRolesList(input.Value);
    }
    
    public static List<RoleFlags> GetRolesList(this RoleFlags input)
    {
        var allValues = Enum.GetValues(typeof(RoleFlags)).Cast<RoleFlags>();

        return allValues.Where(value => value != RoleFlags.None && input.HasFlag(value)).ToList();
    }
}
