using Hid.CheckPoint.Shared.Attributes;
using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Audit.Abstractions.Attributes;
using Hid.Checkpoint.Audit.Abstractions.Enums;

namespace Hid.Checkpoint.Domain.Models;

[AuditedEntity(EntityChangesTypes.All)]
[Metadata("Позиция")]
public class Position : BaseEntity<int>
{
    [Metadata("Название")]
    public string PositionTitle { get; set; }

    [Metadata("Id подразделения")]
    public int? SubdivisionId { get; set; }

    [Metadata("Подразделение")]
    public Subdivision? Subdivision { get; set; }
}
