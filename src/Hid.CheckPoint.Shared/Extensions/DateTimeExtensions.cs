namespace Hid.CheckPoint.Shared;

public static class DateTimeExtensions
{
    public static long ToUnix(this DateTime? input)
    {
        return !input.HasValue ? 0 : input.Value.ToUnix();
    }
    
    public static long ToUnix(this DateTime input)
    {
        var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var unixTimestamp = (long)(input - unixEpoch).TotalSeconds;

        return unixTimestamp;
    }
    
    public static DateTime FromUnix(this long? input)
    {
        return input?.FromUnix() ?? default;
    }
    
    public static DateTime FromUnix(this long input)
    {
        var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var dateTime = unixEpoch.AddSeconds(input);

        return dateTime;
    }
}
