using MediatR;

namespace Hid.Checkpoint.Api.Controllers;

public class PersonsController : HidControllerBase
{
    public PersonsController(IMediator mediator) : base(mediator)
    {
    }
    
    
}
