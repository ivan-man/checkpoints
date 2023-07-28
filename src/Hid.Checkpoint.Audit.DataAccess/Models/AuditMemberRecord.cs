using System.ComponentModel.DataAnnotations;

namespace Hid.Checkpoint.Audit.DataAccess.Models;

public class AuditMemberRecord
{
    [Key] public long Id { get; set; }
    
    public string? DisplayName { get; set; }
    public string PropertyName { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    
    public long AuditEntityRecordId { get; set; }
    public AuditEntityRecord? AuditEntityRecord { get; set; }
}
