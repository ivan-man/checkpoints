using Hid.Checkpoint.Common.Enums;
using Hid.Checkpoint.DataAccess.Ef;
using Hid.Checkpoint.Domain.Models;
using Hid.CheckPoint.Shared;
using Hid.Identity.Client.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hid.Checkpoint.Business.Handlers.Organizations.AddContract;

public class AddOrganizationContractCommandHandler : IRequestHandler<AddOrganizationContractCommand, Result>
{
    private readonly CheckPointsContext _db;
    private readonly ICurrentUserService _currentUserService;
    private readonly ILogger<AddOrganizationContractCommandHandler> _logger;

    public AddOrganizationContractCommandHandler(
        CheckPointsContext db,
        ILogger<AddOrganizationContractCommandHandler> logger, 
        ICurrentUserService currentUserService)
    {
        _db = db;
        _logger = logger;
        _currentUserService = currentUserService;
    }

    public async Task<Result> Handle(AddOrganizationContractCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!_currentUserService.HasAnyPermissions(RoleFlags.Administrator, RoleFlags.Initiator))
                return Result.Forbidden();
            
            var organization = await _db.Organizations
                .FirstOrDefaultAsync(q => !q.Removed && q.Type == OrganizationType.External, cancellationToken);

            if (organization == null)
                return Result.Bad($"Organization with id: '{request.OrganizationId}' not found");
            
            var contract = new OrganizationContract
            {
                OrganizationId = request.OrganizationId,
                Organization = organization, 
                Description = request.Description,
                ValidFrom = request.ValidFrom.HasValue ? DateOnly.FromDateTime(request.ValidFrom.Value) : null,
                ValidTo = request.ValidTo.HasValue ? DateOnly.FromDateTime(request.ValidTo.Value) : null,
            };

            await _db.SaveChangesAsync(cancellationToken);

            return Result.Created();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to add[ contract");
            return Result.Internal("Failed to add contract");
        }
    }
}
