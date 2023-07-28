using Hid.CheckPoint.Shared;
using MediatR;

namespace Hid.Checkpoint.Business.Handlers.Organizations.AddContract;

public class AddOrganizationContractCommand : IRequest<Result>
{
    public int OrganizationId { get; set; }

    public string? Description { get; set; }

    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
}
