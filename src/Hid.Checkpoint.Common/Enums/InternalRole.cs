namespace Hid.Checkpoint.Common.Enums
{
    [Flags]
    public enum InternalPassRequestRole : long
    {
        None = 0,
        Read = 1 << 0,
        Edit = 1 << 1,
        Approve = 1 << 2,
    }
}
