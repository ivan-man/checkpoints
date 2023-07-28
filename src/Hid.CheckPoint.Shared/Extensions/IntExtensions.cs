namespace Hid.CheckPoint.Shared;

public static class IntExtensions
{
    public static Guid ToGuid(this int intValue)
    {
        var intBytes = BitConverter.GetBytes(intValue);
        var guidBytes = new byte[16];
        
        Array.Copy(intBytes, 0, guidBytes, 0, intBytes.Length);
        
        return new Guid(guidBytes);
    }
}
