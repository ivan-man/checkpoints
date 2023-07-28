using Hid.CheckPoint.Shared;
using MediatR;

namespace Hid.Checkpoint.Business.Handlers.Organizations.EditContract;

public class EditOrganizationContractCommand : IRequest<Result>
{
    public int OrganizationContractId { get; set; }

    public string? Description { get; set; }

    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }

    public bool? Removed { get; set; }
}
