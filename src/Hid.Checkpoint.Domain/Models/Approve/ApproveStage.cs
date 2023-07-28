using Hid.CheckPoint.Shared.Attributes;
using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Common.Enums;

namespace Hid.Checkpoint.Domain.Models;

[Metadata("Этап согласования")]
public class ApproveStage : BaseEntity<int>
{
    [Metadata("Id цепочки согласования")]
    public int ChainId { get; set; }

    [Metadata("Цепочка согласования")]
    public ApproveChain Chain { get; set; }

    [Metadata("Порядок")] public int Order { get; set; }
    [Metadata("Статус")] public ApproveState State { get; set; }

    [Metadata("Id заявки")] public int PassRequestId { get; set; }
    [Metadata("Заявка")] public PassRequest PassRequest { get; set; }

    [Metadata("Название")] public string? Title { get; set; }
    [Metadata("Описание")] public string? Description { get; set; }
    [Metadata("Комментарий")] public string? Comment { get; set; }

    [Metadata("Согласовано")] public Person? Approver { get; set; }
    [Metadata("Ответственные")] public List<Person>? Responsibles { get; set; }

    [Metadata("Предыдущий этап согласования")]
    public List<ApproveStage>? PrevStages { get; set; }

    [Metadata("Следующий этап согласования")]
    public List<ApproveStage>? NextStages { get; set; }
    
    /// <summary>
    /// Тип этапа
    /// </summary>
    public int TypeId { get; set; }
    
    /// <summary>
    /// Тип этапа
    /// </summary>
    public StageType? Type { get; set; }
}
