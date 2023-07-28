using Hid.Checkpoint.Common.Enums;
using Hid.Checkpoint.DataAccess.Ef;
using Hid.CheckPoint.Shared;
using Hid.Identity.Client.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hid.Checkpoint.Business.Handlers.Organizations.EditContract;

public class EditOrganizationContractCommandHandler : IRequestHandler<EditOrganizationContractCommand, Result>
{
    private readonly CheckPointsContext _db;
    private readonly ICurrentUserService _currentUserService;
    private readonly ILogger<EditOrganizationContractCommandHandler> _logger;

    public EditOrganizationContractCommandHandler(CheckPointsContext db,
        ICurrentUserService currentUserService, 
        ILogger<EditOrganizationContractCommandHandler> logger)
    {
        _db = db;
        _currentUserService = currentUserService;
        _logger = logger;
    }

    public async Task<Result> Handle(EditOrganizationContractCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!_currentUserService.HasAnyPermissions(RoleFlags.Administrator, RoleFlags.Initiator))
                return Result.Forbidden();
            
            var contract = await _db.OrganizationContracts
                .FirstOrDefaultAsync(q => q.Id == request.OrganizationContractId, cancellationToken);

            if (contract == null)
                return Result.NotFound("Organization contract not found");

            contract.Description = request.Description;
            
            contract.ValidFrom = request.ValidFrom.HasValue
                ? DateOnly.FromDateTime(request.ValidFrom.Value)
                : contract.ValidFrom;
            
            contract.ValidTo = request.ValidTo.HasValue
                ? DateOnly.FromDateTime(request.ValidTo.Value)
                : contract.ValidTo;
            
            contract.Removed = request.Removed ?? contract.Removed;

            await _db.SaveChangesAsync(cancellationToken);

            return Result.Accepted();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to edit contract");
            return Result.Internal("Failed to edit contract");
        }
    }
}
