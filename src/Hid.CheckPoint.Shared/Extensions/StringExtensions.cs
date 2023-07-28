namespace Hid.CheckPoint.Shared;

public static class StringExtensions
{
    public static int? ParseIntSafe(this string? source)
    {
        return !string.IsNullOrWhiteSpace(source) && int.TryParse(source, out var value) ? value : null;
    }

    public static Guid? ParseGuidSafe(this string? source)
    {
        return !string.IsNullOrWhiteSpace(source) && Guid.TryParse(source, out var value) ? value : null;
    }

    public static long? ParseLongSafe(this string? source)
    {
        return !string.IsNullOrWhiteSpace(source) && long.TryParse(source, out var value) ? value : null;
    }
}
