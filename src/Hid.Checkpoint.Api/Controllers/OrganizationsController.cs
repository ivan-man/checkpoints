using Hid.Checkpoint.Business.Handlers.Organizations.CreateExternal;
using Hid.CheckPoint.Shared;
using Hid.Shared.Result.Mvc.Core.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hid.Checkpoint.Api.Controllers;

public class OrganizationsController : HidControllerBase
{
    public OrganizationsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Result<int?>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Result<int?>))]
    public async Task<IActionResult> CreateOrganization([FromBody] CreateExternalOrganizationCommand request)
    {
        var result = await Mediator.Send(request, HttpContext.RequestAborted);

        return result.HttpResponse();
    }
}
