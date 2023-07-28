using System;
using Hid.Checkpoint.Audit.Abstractions.Enums;

namespace Hid.Checkpoint.Audit.Abstractions.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AuditedEntityAttribute : Attribute
    {
        public EntityChangesTypes MonitoredChanges { get; }

        public AuditedEntityAttribute(
            EntityChangesTypes monitoredChanges = EntityChangesTypes.None)
        {
            MonitoredChanges = monitoredChanges;
        }
    }
}
