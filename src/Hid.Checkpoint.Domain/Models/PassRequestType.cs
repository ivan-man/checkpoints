using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Audit.Abstractions.Attributes;
using Hid.Checkpoint.Audit.Abstractions.Enums;

namespace Hid.Checkpoint.Domain.Models;

[AuditedEntity(EntityChangesTypes.All)]
public class PassRequestType : BaseEntity<int>
{
    public string DisplayName { get; set; }
    public string? Description { get; set; }

    public bool Enabled { get; set; } = true;
    
    /// <summary>
    /// Выдается на КПП
    /// </summary>
    public bool IsCheckpointIssue  { get; set; }
    
    /// <summary>
    /// Срок действия
    /// </summary>
    public TimeSpan? ValidityPeriod { get; set; }

    /// <summary>
    /// Максимальный срок действия
    /// </summary>
    public TimeSpan? MaxValidityPeriod { get; set; }
}
