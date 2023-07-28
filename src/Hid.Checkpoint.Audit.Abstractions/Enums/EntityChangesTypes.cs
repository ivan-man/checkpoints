using System;

namespace Hid.Checkpoint.Audit.Abstractions.Enums
{
    [Flags]
    public enum EntityChangesTypes
    {
        /// <summary>
        /// If you need track only nested members.
        /// </summary>
        None,
        
        Added = 1 << 0,
        Modified = 1 << 1,
        Deleted = 1 << 2,
        
        All = Added | Modified | Deleted,
    }
}
