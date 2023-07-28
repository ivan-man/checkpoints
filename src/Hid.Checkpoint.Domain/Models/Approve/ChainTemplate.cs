using Hid.CheckPoint.Shared.Attributes;
using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Audit.Abstractions.Attributes;
using Hid.Checkpoint.Audit.Abstractions.Enums;

namespace Hid.Checkpoint.Domain.Models;

[AuditedEntity(EntityChangesTypes.All)]
[Metadata("Цепочка согласования")]
public class ChainTemplate : BaseEntity<int>
{
    public bool IsDisabled { get; set; }
    
    public int TypeId { get; set; }
    public PassRequestType Type { get; set; }
    public List<StageTemplate> Stages { get; set; }
}
