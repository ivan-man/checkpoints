namespace Hid.Checkpoint.Audit;

public class AuditMemberRecordViewModel
{
    public long? Id { get; set; }
    
    public string? DisplayName { get; set; }
    public string PropertyName { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
}
