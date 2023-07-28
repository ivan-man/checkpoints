using Hid.Checkpoint.Common.Enums;
using Hid.Checkpoint.Common.Extensions;
using Hid.Checkpoint.DataAccess.Ef;
using Hid.Checkpoint.Domain.Models;
using Hid.CheckPoint.Shared;
using Hid.Identity.Client;
using Hid.Identity.Client.Services;
using Hid.Identity.Common.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hid.Checkpoint.Business.Handlers.Users.GetUser;

public class GetUserApiCommandHandler : IRequestHandler<GetUserApiCommand, Result<UserContract?>>
{
    private readonly IUnitOfWork _uow;
    private readonly IIdentityService _identityService;
    private readonly ICurrentUserService _currentUserService;
    private readonly ILogger<GetUserApiCommandHandler> _logger;

    public GetUserApiCommandHandler(
        ILogger<GetUserApiCommandHandler> logger,
        IUnitOfWork uow, 
        IIdentityService identityService, ICurrentUserService currentUserService)
    {
        _logger = logger;
        _uow = uow;
        _identityService = identityService;
        _currentUserService = currentUserService;
    }

    public async Task<Result<UserContract?>> Handle(GetUserApiCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if(!_currentUserService.HasAnyPermissions(RoleFlags.Administrator, RoleFlags.ApproversConfirmation))
                return Result<UserContract?>.Forbidden();
            
            Person? person;
            
            if (request.PersonId.HasValue)
            {
                person = await _uow.Persons.GetByIdAsync(request.PersonId.Value, cancellationToken);
            }
            else if (!string.IsNullOrWhiteSpace(request.ExternalEmployeeId) 
                     && Guid.TryParse(request.ExternalEmployeeId, out var extEmployeeId))
            {
                person = await _uow.Persons.AsQueryable()
                    .Where(q => q.Profiles.Any(p => p.DisabledDate == null && p.ExternalId == extEmployeeId))
                    .SingleOrDefaultAsync(cancellationToken: cancellationToken);
            }
            else
            {
                return Result<UserContract?>.ImTeapot("Invalid request.");
            }
            
            if(person == null)
                return Result<UserContract?>.NotFound("User not found.");

            var contract = new GetUserContract
            {
                Email = person.Profile.Email,
                ExternalEmployeeId = person.Profile.ExternalId.ToString(),
                PersonId = person.Id,
                UserName = person.Profile.GetInitials(),
                PhoneNumber = person.Profile.Phone,
            };

            return await _identityService.GetUserAsync(contract, cancellationToken);

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to get user by {@Request}", request);
            return Result<UserContract?>.Internal("Failed to get user.");
        }
    }
}
