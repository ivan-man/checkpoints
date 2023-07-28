using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Audit.Abstractions.Attributes;
using Hid.Checkpoint.Audit.Abstractions.Enums;

namespace Hid.Checkpoint.Domain.Models;

[AuditedEntity(EntityChangesTypes.All)]
public class StageType : BaseEntity<int>
{
    public string Title { get; set; }
    public string? Description { get; set; }
    
    public bool MultipleStage { get; set; }
    public bool ApproversListOpened { get; set; } = true;
    public bool WeekEndAccess { get; set; }
}
