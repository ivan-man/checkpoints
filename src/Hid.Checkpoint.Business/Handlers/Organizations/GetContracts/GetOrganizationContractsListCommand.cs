using Hid.Checkpoint.Common.ViewModels;
using Hid.CheckPoint.Shared;
using MediatR;

namespace Hid.Checkpoint.Business.Handlers.Organizations.GetContracts;

public class GetOrganizationContractsListCommand : IRequest<ResultList<OrganizationContractViewModel>>
{
    public int OrganizationId { get; set; }
}
