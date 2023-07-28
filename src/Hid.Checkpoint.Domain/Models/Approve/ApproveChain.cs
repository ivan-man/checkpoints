using Hid.CheckPoint.Shared.Attributes;
using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Audit.Abstractions.Attributes;
using Hid.Checkpoint.Audit.Abstractions.Enums;
using Hid.Checkpoint.Common.Enums;

namespace Hid.Checkpoint.Domain.Models;

[AuditedEntity(EntityChangesTypes.All)]
public class ApproveChain : BaseEntity<int>
{
    [Metadata("Текущее состояние")] public ApproveState ApproveState { get; set; }

    [Metadata("Заголовок")] public string Title { get; set; }
    [Metadata("Комментарий")] public string? Comment { get; set; }

    [Metadata("Идентификатор запроса")] public int PassRequestId { get; set; }
    public PassRequest PassRequest { get; set; }

    [Metadata("Текущий этап")] public int CurrentStageId { get; set; }
    public ApproveStage CurrentStage { get; set; }

    public List<ApproveStage> Stages { get; set; }
}
