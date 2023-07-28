using MediatR;

namespace Hid.Checkpoint.Api.Controllers;

public class RolesController : HidControllerBase
{
    public RolesController(IMediator mediator) : base(mediator)
    {
    }
}
