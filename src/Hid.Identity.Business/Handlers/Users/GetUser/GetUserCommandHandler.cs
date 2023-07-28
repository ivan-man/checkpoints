using Hid.Checkpoint.Common.Enums;
using Hid.CheckPoint.Shared;
using Hid.Identity.Common.Contracts;
using Hid.Identity.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hid.Identity.Business.Handlers.Users.GetUser;

public class GetUserCommandHandler : IRequestHandler<GetUserCommand, Result<UserContract?>>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationUserRole> _roleManager;
    private readonly ILogger<GetUserCommandHandler> _logger;

    public GetUserCommandHandler(
        UserManager<ApplicationUser> userManager,
        ILogger<GetUserCommandHandler> logger,
        RoleManager<ApplicationUserRole> roleManager)
    {
        _logger = logger;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task<Result<UserContract?>> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ApplicationUser? user = null;

            if (request.PersonId.HasValue)
            {
                user = await _userManager.Users
                    .SingleOrDefaultAsync(q => q.PersonId == request.PersonId.Value, cancellationToken);
            }
            else if (!string.IsNullOrWhiteSpace(request.UserName))
            {
                user = await _userManager.FindByNameAsync(request.UserName);
            }
            else if (!string.IsNullOrWhiteSpace(request.ExternalEmployeeId))
            {
                user = await _userManager.Users
                    .SingleOrDefaultAsync(q => q.ExternalEmployeeId.Equals(request.ExternalEmployeeId),
                        cancellationToken);
            }
            else if (!string.IsNullOrWhiteSpace(request.Email))
            {
                user = await _userManager.FindByEmailAsync(request.Email);
            }
            else if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                user = await _userManager.Users
                    .SingleOrDefaultAsync(q => q.PhoneNumber!.Equals(request.PhoneNumber), cancellationToken);
            }

            if (user is null)
                return Result<UserContract?>.NotFound();

            var userRoles = RoleFlags.None;

            var roles = await GetUserRolesAsync(user, cancellationToken);
            if (roles.Any())
            {
                userRoles = roles.Aggregate(RoleFlags.None, (current, role) => current | role.Role);
            }

            var viewModel = new UserContract
            {
                ExternalEmployeeId = user.ExternalEmployeeId,
                PersonId = user.PersonId,
                RolesValue = userRoles,
                Id = user.Id,
            };

            return Result<UserContract?>.Ok(viewModel);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to create user {@Request}", request);
            return Result<UserContract?>.Internal("Failed to get user");
        }
    }

    private async Task<List<ApplicationUserRole>> GetUserRolesAsync(
        ApplicationUser user,
        CancellationToken cancellationToken = default)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

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

        return userRoles;
    }
}
