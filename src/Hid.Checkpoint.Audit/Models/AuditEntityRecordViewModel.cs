using Hid.Checkpoint.Audit.Abstractions.Enums;
using Hid.Checkpoint.Audit.DataAccess.Models;

namespace Hid.Checkpoint.Audit.Models;

public class AuditEntityRecordViewModel
{
    public long? Id { get; set; }
    
    public int? EmployeeId { get; set; }
    public int? ProfileId { get; set; }
    public string UserInfo { get; set; }
        
    public string? DisplayName { get; set; }
    public string EntityId { get; set; }
    public string EntityType { get; set; }
    public string EntityFullType { get; set; }
    public ChangesType? ChangesType { get; set; }
    public ChangesInitiatorType InitiatorType { get; set; } = ChangesInitiatorType.Unknown;
        
    public DateTime Stamp { get; set; } = DateTime.UtcNow;
    public DateTime? Expired { get; set; }
    
    public List<AuditMemberRecord> AuditMembers { get; set; }
}
