using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Audit.Abstractions.Attributes;
using Hid.Checkpoint.Audit.Abstractions.Enums;
using Hid.CheckPoint.Shared.Attributes;

namespace Hid.Checkpoint.Domain.Models;

[AuditedEntity(EntityChangesTypes.All)]
public class AccessPoint : BaseEntity<int>
{
    [Metadata("Сквозной Id")] public int GlobalId { get; set; }
    [Metadata("Название")] public string Name { get; set; }
    
    [Metadata("Уровни доступа")] 
    public List<AccessLevel>? AccessLevels { get; set; }
}
