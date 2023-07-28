using MediatR;

namespace Hid.Checkpoint.Api.Controllers;

public class PermissionsController : HidControllerBase
{
    public PermissionsController(IMediator mediator) : base(mediator)
    {
    }
}
