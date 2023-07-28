using Hid.Checkpoint.Audit.Abstractions.Attributes;
using Hid.Checkpoint.Audit.Abstractions.Enums;
using Microsoft.EntityFrameworkCore;

namespace Hid.Checkpoint.Domain.Models;

[Owned]
[AuditedEntity(EntityChangesTypes.All)]
public class StageTemplate
{
    /// <summary>
    /// Порядковый номер
    /// </summary>
    public int Order { get; set; }
    
    public bool IsDisabled { get; set; }
    
    public int ChainTemplateId { get; set; }
    public ChainTemplate? ChainTemplate { get; set; }

    /// <summary>
    /// Тип этапа
    /// </summary>
    public int TypeId { get; set; }
    
    /// <summary>
    /// Тип этапа
    /// </summary>
    public StageType Type { get; set; }
}
