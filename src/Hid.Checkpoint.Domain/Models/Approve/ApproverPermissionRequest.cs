using Hid.CheckPoint.Shared.Domain;

namespace Hid.Checkpoint.Domain.Models;

public class ApproverPermissionRequest : BaseEntity<int>
{
    public int AuthorId { get; set; }
    public Person? Author { get; set; }
    
    public int PersonId { get; set; }
    public Person? Person { get; set; }
    
    public int? PassRequestTypeId { get; set; }
    public PassRequestType? PassRequestType { get; set; }
    
    public int? SubdivisionId { get; set; }
    public Subdivision? Subdivision { get; set; }
    
    public int? StageTypeId { get; set; }
    public StageType? StageType { get; set; }
    
    public int? StageTemplateId { get; set; }
    public StageTemplate? StageTemplate { get; set; }
    
    public bool? Accepted { get; set; }
    public string? RejectReason { get; set; }
    
    /// <summary>
    /// Список уровней доступа
    /// </summary>
    public List<AccessLevel>? AccessLevels { get; set; }
}
