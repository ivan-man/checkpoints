using Hid.Checkpoint.Common.ViewModels;
using Hid.CheckPoint.Shared;
using MediatR;

namespace Hid.Checkpoint.Business.Handlers.Organizations.Get;

public class GetOrganizationCommand : IRequest<Result<OrganizationViewModel>>
{
    public int? Id { get; set; }
    public Guid? ExternalId { get; set; }
}
