namespace Hid.Checkpoint.Audit.Abstractions.Models
{
    public class AuditMemberEvent
    {
        public string DisplayName { get; set; }
        
        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
