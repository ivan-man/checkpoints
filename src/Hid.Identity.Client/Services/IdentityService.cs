using Hid.CheckPoint.Shared;
using Hid.Identity.Business.Handlers.Login;
using Hid.Identity.Business.Handlers.Roles.AddUserRole;
using Hid.Identity.Business.Handlers.Roles.RemoveUserRole;
using Hid.Identity.Business.Handlers.TokenValidation;
using Hid.Identity.Business.Handlers.Users.Create;
using Hid.Identity.Business.Handlers.Users.GetUser;
using Hid.Identity.Common.Contracts;
using Mapster;
using MediatR;

namespace Hid.Identity.Client.Services;

internal class IdentityService : IIdentityService
{
    private readonly IMediator _mediator;

    public IdentityService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async ValueTask<Result> ValidateTokenAsync(ValidateTokenContract request, CancellationToken token = default)
    {
        var result = await _mediator.Send(request.Adapt<ValidateTokenCommand>(), token)
            .ConfigureAwait(false);

        return result;
    }

    public async ValueTask<Result<TokenContract>> LoginAsync(
        LoginContract request,
        CancellationToken token = default)
    {
        var result = await _mediator.Send(request.Adapt<LoginCommand>(), token)
            .ConfigureAwait(false);

        return result;
    }

    public async ValueTask<Result<UserContract?>> GetUserAsync(GetUserContract request,
        CancellationToken token = default)
    {
        var result = await _mediator.Send(request.Adapt<GetUserCommand>(), token)
            .ConfigureAwait(false);

        return result;
    }

    public async ValueTask<Result> AddUserRoleAsync(AddUserRoleContract request, CancellationToken token = default)
    {
        var result = await _mediator.Send(request.Adapt<AddUserRoleCommand>(), token)
            .ConfigureAwait(false);

        return result;
    }

    public async ValueTask<Result> RemoveUserRoleAsync(RemoveUserRoleContract request,
        CancellationToken token = default)
    {
        var result = await _mediator.Send(request.Adapt<RemoveUserRoleCommand>(), token)
            .ConfigureAwait(false);

        return result;
    }

    public async ValueTask<Result<Guid?>> CreateUserAsync(CreateUserContract request, CancellationToken token = default)
    {
        var result = await _mediator.Send(new CreateUserCommand
        {
            PersonId = request.PersonId,
            RolesValue = request.RolesValue,
            UserName = request.Login,
            ExternalEmployeeId = request.ExternalEmployeeId!,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            UserSecret = request.UserSecret,
        }, token).ConfigureAwait(false);

        return result;
    }
}
