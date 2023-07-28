using Hid.Checkpoint.Common.Enums;
using Hid.Checkpoint.Common.Extensions;
using Hid.Checkpoint.DataAccess.Ef;
using Hid.CheckPoint.Shared;
using Hid.Identity.Client;
using Hid.Identity.Client.Services;
using Hid.Identity.Common;
using Hid.Identity.Common.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Hid.Checkpoint.Business.Handlers.Users.Create;

public class CreateUserApiCommandHandler : IRequestHandler<CreateUserApiCommand, Result<Guid?>>
{
    private readonly IUnitOfWork _uow;
    private readonly IIdentityService _identityService;
    private readonly ICurrentUserService _currentUserService;
    private readonly JwtOptions _jwtOptions;
    private readonly ILogger<CreateUserApiCommandHandler> _logger;

    public CreateUserApiCommandHandler(
        IUnitOfWork uow, 
        IIdentityService identityService, 
        ICurrentUserService currentUserService, 
        IOptions<JwtOptions> jwtOptions, 
        ILogger<CreateUserApiCommandHandler> logger)
    {
        _uow = uow;
        _identityService = identityService;
        _currentUserService = currentUserService;
        _jwtOptions = jwtOptions.Value;
        _logger = logger;
    }

    public async Task<Result<Guid?>> Handle(CreateUserApiCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var currentUser = _currentUserService.GetCurrentUser();
            if (currentUser?.RolesValue.HasFlag(RoleFlags.Administrator) != true)
            {
                _logger.LogWarning("{@User} tried to create new user by {@Command}", currentUser, request);
                return Result<Guid?>.Forbidden();
            }

            var person = await _uow.Persons.GetByIdAsync(request.PersonId, cancellationToken);
            if (person == null || person.Removed)
                return Result<Guid?>.NotFound($"Person with Id: {request.PersonId} not found");
            
            if(person.Profile?.IsEmployee != true)
                return Result<Guid?>.ImTeapot("Target person is not employee");

            var rolesValue = request.Roles.Distinct()
                .Aggregate(RoleFlags.None, (current, role) => current | role);

            var contract = new CreateUserContract
            {
                PersonId = person.Id,
                RolesValue = rolesValue,
                Login = person.Profile.GetInitials(),
                ExternalEmployeeId = person.Profile.ExternalId.ToString(),
                Email = person.Profile.Email,
                PhoneNumber = person.Profile.Phone,
                UserSecret = _jwtOptions.UserSecret,
            };

            var userResponse = await _identityService.CreateUserAsync(contract, cancellationToken);
            if (userResponse is not { Success: true, Data: not null })
                return userResponse;
            
            person.UserId = userResponse.Data.Value;
            await _uow.SaveChangesAsync(cancellationToken);

            return userResponse;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to create user by {@Command}", request);
            return Result<Guid?>.Internal("Failed to create user");
        }
    }
}
