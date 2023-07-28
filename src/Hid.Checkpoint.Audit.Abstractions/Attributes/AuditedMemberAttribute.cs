using System;

namespace Hid.Checkpoint.Audit.Abstractions.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AuditedMemberAttribute : Attribute
    {
        public AuditedMemberAttribute() 
        {
        }
    }
}
