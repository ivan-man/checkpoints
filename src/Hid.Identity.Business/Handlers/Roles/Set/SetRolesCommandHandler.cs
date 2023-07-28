using Hid.Checkpoint.Common.Enums;
using Hid.CheckPoint.Shared;
using Hid.Identity.Business.Handlers.Roles.CreateIfNotExists;
using Hid.Identity.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hid.Identity.Business.Handlers.Roles.Set;

public class SetRolesCommandHandler : IRequestHandler<SetRolesCommand, Result>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMediator _mediator;
    private readonly ILogger<SetRolesCommandHandler> _logger;


    public SetRolesCommandHandler(
        UserManager<ApplicationUser> userManager, 
        ILogger<SetRolesCommandHandler> logger, 
        IMediator mediator)
    {
        _userManager = userManager;
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<Result> Handle(SetRolesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ApplicationUser? user;

            if (request.EmployeeId.HasValue)
            {
                user = await _userManager.Users
                    .FirstOrDefaultAsync(
                        q => q.PersonId == request.EmployeeId.Value,
                        cancellationToken: cancellationToken);
            }
            else if (request.UserId.HasValue)
            {
                user = await _userManager.FindByIdAsync(request.UserId.ToString()!);
            }
            else if (!string.IsNullOrWhiteSpace(request.ExternalEmployeeId))
            {
                user = await _userManager.Users
                    .FirstOrDefaultAsync(
                        q => q.ExternalEmployeeId == request.ExternalEmployeeId,
                        cancellationToken: cancellationToken);
            }
            else
            {
                throw new InvalidOperationException("Failed to get user, Invalid request");
            }

            if (user is null)
            {
                _logger.LogWarning("Failed to found user by {@Request}", request);
                return Result.NotFound("User not found");
            }

            var rolesList = Enum.GetValues<RoleFlags>();
            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var roleValue in rolesList)
            {
                if (!request.RolesValue.HasFlag(roleValue) && !userRoles.Any(q =>
                        q.Equals(roleValue.ToString(), StringComparison.InvariantCultureIgnoreCase)))
                {
                    continue;
                }

                var checkRoleResult = await _mediator.Send(new CreateRoleIfNotExistsCommand
                {
                    Role = roleValue
                }, cancellationToken);

                if (!checkRoleResult.Success)
                    return Result.Failed(checkRoleResult);

                if (!userRoles.Contains(roleValue.ToString()) && request.RolesValue.HasFlag(roleValue))
                {
                    var setRoleResult = await _userManager.AddToRoleAsync(user, roleValue.ToString());
                    if (!setRoleResult.Succeeded)
                    {
                        _logger.LogError("Failed to add {@Role} to {userId}", roleValue, user.Id);
                        return Result.Internal("Failed to add role to user");
                    }
                }

                if (userRoles.Any(q => q.Equals(roleValue.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    && !request.RolesValue.HasFlag(roleValue))
                {
                    var removeRoleResult = await _userManager.RemoveFromRoleAsync(user, roleValue.ToString());
                    if (!removeRoleResult.Succeeded)
                    {
                        _logger.LogError("Failed to remove {@Role} from {userId}", roleValue, user.Id);
                        return Result.Internal("Failed to remove role from user");
                    }
                }
            }

            return Result.Accepted();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to set roles by {@Request}", request);
            return Result.Internal("Failed to set roles");
        }
    }
}
