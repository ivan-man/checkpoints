using MediatR;

namespace Hid.Checkpoint.Api.Controllers;

public class AuthController : HidControllerBase
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }
}
