using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Audit.Abstractions.Attributes;
using Hid.Checkpoint.Audit.Abstractions.Enums;
using Hid.Checkpoint.Common.Enums;
using Hid.CheckPoint.Shared.Attributes;

namespace Hid.Checkpoint.Domain.Models;

[AuditedEntity(EntityChangesTypes.All)]
public class AccessLevel : BaseEntity<int>
{
    [Metadata("Сквозной Id")] public int GlobalId { get; set; }

    [Metadata("Название")] public string Name { get; set; }
    [Metadata("Комментарий")] public string Comment { get; set; }

    [Metadata("Время начала доступа")] public TimeOnly AccessTimeFrom { get; set; }
    [Metadata("Время окончания доступа")] public TimeOnly AccessTimeTo { get; set; }
    
    [Metadata("Дни недели")] 
    public DaysOfWeekFlags DaysOfWeek { get; set; }
    
    [Metadata("Доступ в выходные дни")] 
    public bool WeekendAccess { get; set; }

    [Metadata("Точки доступа")] 
    public List<AccessPoint>? AccessPoints { get; set; }

    [Metadata("Согласующие")] 
    public List<Person>? Approvers { get; set; }
}
