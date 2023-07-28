using Hid.Checkpoint.Audit.Abstractions.Attributes;
using Hid.Checkpoint.Audit.Abstractions.Enums;
using Hid.CheckPoint.Shared.Domain;

namespace Hid.Checkpoint.Domain.Models;

[AuditedEntity(EntityChangesTypes.All)]
public class ApprovePermission : BaseEntity<int>
{
    public int PersonId { get; set; }
    /// <summary>
    /// Согласующий
    /// </summary>
    public Person? Person { get; set; }
    
    public int? PassRequestTypeId { get; set; }
    public PassRequestType? RequestType { get; set; }
    
    public int? StageTypeId { get; set; }
    public StageType? StageType { get; set; }

    public int? StageTemplateId { get; set; }
    public StageTemplate? StageTemplate { get; set; }
    
    public int? SubdivisionId { get; set; }
    public Subdivision? Subdivision { get; set; }
    
    /// <summary>
    /// Список уровней доступа
    /// </summary>
    public List<AccessLevel>? AccessLevels { get; set; }
    
    public bool IsDisabled { get; set; }
}
