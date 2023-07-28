using Hid.Checkpoint.Common.Enums;
using Hid.CheckPoint.Shared;
using Hid.Identity.Business.Handlers.Roles.Set;
using Hid.Identity.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hid.Identity.Business.Handlers.Roles.AddUserRole;

public class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommand, Result>
{
    private readonly RoleManager<ApplicationUserRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMediator _mediator;
    private readonly ILogger<SetRolesCommandHandler> _logger;


    public AddUserRoleCommandHandler(RoleManager<ApplicationUserRole> roleManager, UserManager<ApplicationUser> userManager, ILogger<SetRolesCommandHandler> logger, IMediator mediator)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<Result> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ApplicationUser? user;

            if (request.PersonId.HasValue)
            {
                user = await _userManager.Users
                    .FirstOrDefaultAsync(
                        q => q.PersonId == request.PersonId.Value,
                        cancellationToken: cancellationToken);
            }
            else if (request.UserId.HasValue)
            {
                user = await _userManager.Users
                    .FirstOrDefaultAsync(
                        q => q.Id == request.UserId.Value,
                        cancellationToken: cancellationToken);
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

            var userRoleIds = await _userManager.GetRolesAsync(user);
            var userRoles = new List<ApplicationUserRole>();
            
            foreach (var roleId in userRoleIds)
            {
                var role = await _roleManager.FindByIdAsync(roleId);
                if (role != null)
                {
                    userRoles.Add(role);
                }
            }
            
            var userRoleValue = userRoles.Aggregate(RoleFlags.None, (current, role) => current | role.Role);
            if (userRoleValue.HasFlag(request.RoleValue))
                return Result.Accepted();

            var targetRoleValue = userRoleValue | request.RoleValue;

            return await _mediator.Send(new SetRolesCommand
            {
                EmployeeId = request.PersonId,
                UserId = request.UserId,
                ExternalEmployeeId = request.ExternalEmployeeId,
                RolesValue = targetRoleValue,
            }, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to set roles by {@Request}", request);
            return Result.Internal("Failed to set roles");
        }
    }
}
