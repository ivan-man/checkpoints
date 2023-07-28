using Hid.Checkpoint.Common.Enums;
using Hid.Checkpoint.DataAccess.Ef;
using Hid.Checkpoint.Domain.Models;
using Hid.CheckPoint.Shared;
using Hid.Identity.Client.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Hid.Checkpoint.Business.Handlers.Organizations.CreateExternal;

public class CreateExternalOrganizationCommandHandler : IRequestHandler<CreateExternalOrganizationCommand, Result<int>>
{
    private readonly CheckPointsContext _db;
    private readonly ICurrentUserService _currentUserService;
    private readonly ILogger<CreateExternalOrganizationCommandHandler> _logger;

    public CreateExternalOrganizationCommandHandler(
        ILogger<CreateExternalOrganizationCommandHandler> logger,
        ICurrentUserService currentUserService, 
        CheckPointsContext db)
    {
        _logger = logger;
        _currentUserService = currentUserService;
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateExternalOrganizationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!_currentUserService.HasAnyPermissions(RoleFlags.Administrator, RoleFlags.Initiator))
                return Result<int>.Forbidden();
            
            var organization = new Organization
            {
                Address = request.Address,
                Description = request.Description,
                Name = request.Name,
                Type = OrganizationType.External,
            };

            if (!string.IsNullOrWhiteSpace(request.Description))
            {
                var contract = new OrganizationContract
                {
                    Description = request.Description,
                    ValidFrom = request.ValidFrom,
                    ValidTo = request.ValidTo,
                    Organization = organization,
                };
                
                organization.Contracts.Add(contract);
            }

            _db.Organizations.Add(organization);

            await _db.SaveChangesAsync(cancellationToken);

            return Result<int>.Created(organization.Id);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to create organization by {@Request}", request);
            return Result<int>.Internal("Failed to create organization.");
        }
    }
}
