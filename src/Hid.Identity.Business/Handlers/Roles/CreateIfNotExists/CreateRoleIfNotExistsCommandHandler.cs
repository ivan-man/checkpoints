using Hid.Checkpoint.Common.Enums;
using Hid.CheckPoint.Shared;
using Hid.Identity.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Hid.Identity.Business.Handlers.Roles.CreateIfNotExists;

public class CreateRoleIfNotExistsCommandHandler : IRequestHandler<CreateRoleIfNotExistsCommand, Result<ApplicationUserRole>>
{
    private readonly RoleManager<ApplicationUserRole> _roleManager;
    private readonly ILogger<CreateRoleIfNotExistsCommandHandler> _logger;

    public CreateRoleIfNotExistsCommandHandler(
        RoleManager<ApplicationUserRole> roleManager,
        ILogger<CreateRoleIfNotExistsCommandHandler> logger)
    {
        _roleManager = roleManager;
        _logger = logger;
    }

    public async Task<Result<ApplicationUserRole>> Handle(CreateRoleIfNotExistsCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var allRoles = Enum.GetValues<RoleFlags>();
            if (allRoles.All(q => q != request.Role))
                return Result<ApplicationUserRole>.ImTeapot($"Invalid value for role: {request.Role}-{request.Role.ToString()}");
            
            var existingRole = await _roleManager.FindByIdAsync(((int)request.Role).ToGuid().ToString());
            if (existingRole == null)
            {
                var newRole = new ApplicationUserRole
                {
                    Id = ((int)request.Role).ToGuid(),
                    Name = request.Role.ToString(),
                    NormalizedName = request.Role.ToString().ToUpper(),
                    Role = request.Role,
                };

                var roleCreatingResult = await _roleManager.CreateAsync(newRole);
                if (roleCreatingResult.Succeeded) 
                    return Result<ApplicationUserRole>.Created(newRole);
                
                _logger.LogError("Failed to create {@Role} with {@Result}", newRole, roleCreatingResult);
                return Result<ApplicationUserRole>.Internal("Failed to create new role");
            }
            
            return Result<ApplicationUserRole>.Ok(existingRole);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to create {Role}", request.Role);
            return Result<ApplicationUserRole>.Internal("Failed to create role");
        }
    }
}
