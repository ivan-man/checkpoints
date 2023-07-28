using Hid.Checkpoint.Business.Handlers.Users.Create;
using Hid.CheckPoint.Shared;
using Hid.Identity.Business.Handlers.Users.GetUser;
using Hid.Shared.Result.Mvc.Core.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hid.Checkpoint.Api.Controllers;

[Route("api/[controller]")]
public class UsersController : HidControllerBase
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Result<Guid?>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Result<Guid?>))]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserApiCommand request)
    {
        var result = await Mediator.Send(request, HttpContext.RequestAborted);
        return result.HttpResponse();
    }

    [HttpGet]
    // [Authorize(Roles = "Administrator, ApproversConfirmation")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Result<Guid?>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Result<Guid?>))]
    public async Task<IActionResult> GetUserAsync([FromBody] GetUserCommand request)
    {
        var result = await Mediator.Send(request, HttpContext.RequestAborted);
        return result.HttpResponse();
    }
    
}
