using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hid.Checkpoint.Api.Controllers;

public abstract class HidControllerBase : ControllerBase
{
    protected readonly IMediator Mediator;

    protected HidControllerBase(IMediator mediator)
    {
        Mediator = mediator;
    }
}
