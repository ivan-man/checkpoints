using Hid.CheckPoint.Shared.Attributes;
using Hid.CheckPoint.Shared.Domain;

namespace Hid.Checkpoint.Domain.Models;

public class OrganizationContract : BaseEntity<int>
{
    [Metadata("Идентификатор")] public int OrganizationId { get; set; }
    [Metadata(true)] public Organization? Organization { get; set; }

    [Metadata("Основание")] public string? Description { get; set; }

    [Metadata("Действует с")] public DateOnly? ValidFrom { get; set; }
    [Metadata("Действует по")] public DateOnly? ValidTo { get; set; }

    [Metadata(true)] public List<GuestContractRelation>? GuestContractRelations { get; set; }
}
