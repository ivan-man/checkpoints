using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Audit.Abstractions.Attributes;
using Hid.Checkpoint.Audit.Abstractions.Enums;
using Hid.Checkpoint.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace Hid.Checkpoint.Domain.Models;

[Owned, AuditedEntity(EntityChangesTypes.All)]
public class DocumentCopy : BaseEntity<int>
{
    public DocumentType Type { get; set; }

    public string? Series { get; set; }
    public string? Number { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    // public List<FileEntity>? Copies { get; set; } = new();
}
