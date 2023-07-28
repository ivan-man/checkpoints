using Hid.CheckPoint.Shared;
using MediatR;

namespace Hid.Checkpoint.Business.Handlers.Organizations.CreateExternal;

public class CreateExternalOrganizationCommand : IRequest<Result<int>>
{
    public string Name { get; set; }

    public string? Address { get; set; }

    public string? Description { get; set; }
    
    public string? ContractDescription { get; set; }
    
    public DateOnly? ValidFrom { get; set; }
    
    public DateOnly? ValidTo { get; set; }
}
