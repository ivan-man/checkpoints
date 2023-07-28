using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Hid.CheckPoint.Shared;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        var memberName = enumValue.ToString();
        var member = enumValue.GetType()
            .GetMember(memberName)
            .FirstOrDefault();

        var displayName = member?.GetCustomAttribute<DisplayAttribute>()?.GetName() 
            ?? member?.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
        
        return displayName ?? (memberName.ToUpperInvariant().Equals("NONE") ? "-" : memberName);
    }
}
