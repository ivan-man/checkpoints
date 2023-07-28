using Hid.Checkpoint.Common.Interfaces;

namespace Hid.Checkpoint.Common.Extensions;

public static class PersonExtensions
{
    public static string GetFullName(this IPersonName person)
    {
        return $"{person.Surname} {person.Name} {person.Patronymic}".Trim();
    }
    
    public static string GetInitials(this IPersonName source)
    {
        return $"{source.Surname} {(string.IsNullOrWhiteSpace(source.Name) ? string.Empty : source.Name[0] + ".")} {(string.IsNullOrWhiteSpace(source.Patronymic) ? string.Empty : source.Patronymic[0] + ".")}".Trim();
    }
}
