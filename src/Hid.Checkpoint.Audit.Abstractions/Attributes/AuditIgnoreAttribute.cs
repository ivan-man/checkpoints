using System;

namespace Hid.Checkpoint.Audit.Abstractions.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AuditIgnoreAttribute : Attribute
    {
        public AuditIgnoreAttribute()
        {
        }
    }
}
