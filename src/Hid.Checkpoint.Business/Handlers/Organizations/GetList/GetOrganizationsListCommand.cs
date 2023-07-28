using Hid.Checkpoint.Common.Enums;
using Hid.Checkpoint.Common.ViewModels;
using Hid.CheckPoint.Shared.PaginationResult;
using MediatR;

namespace Hid.Checkpoint.Business.Handlers.Organizations.GetList;

public class GetOrganizationsListCommand : PaginationBaseCommand, IRequest<PaginationResult<OrganizationViewModel>>
{
    public List<int>? Id { get; set; }
    public List<Guid>? ExternalId { get; set; }
    public OrganizationType? Type { get; set; }
    public string? Search { get; set; }
    public string? Inn { get; set; }
    public string? Kpp { get; set; }
    public string? Okpo { get; set; }
    public string? Okato { get; set; }
    public string? Imns { get; set; }
}
