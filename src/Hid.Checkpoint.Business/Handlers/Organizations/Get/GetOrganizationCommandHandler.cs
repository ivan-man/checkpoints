using Hid.Checkpoint.Common.ViewModels;
using Hid.Checkpoint.DataAccess.Ef;
using Hid.Checkpoint.Domain.Models;
using Hid.CheckPoint.Shared;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hid.Checkpoint.Business.Handlers.Organizations.Get;

public class GetOrganizationCommandHandler : IRequestHandler<GetOrganizationCommand, Result<OrganizationViewModel>>
{
    private readonly CheckPointsContext _db;
    private readonly ILogger<GetOrganizationCommandHandler> _logger;

    public GetOrganizationCommandHandler(CheckPointsContext db, ILogger<GetOrganizationCommandHandler> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<Result<OrganizationViewModel>> Handle(GetOrganizationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var organization = request.Id.HasValue 
                ? await _db.Organizations.FirstOrDefaultAsync(q => q.Id == request.Id.Value, cancellationToken)
                : await _db.Organizations.FirstOrDefaultAsync(q => q.ExternalId == request.ExternalId!.Value, cancellationToken);

            return organization != null
                ? Result<OrganizationViewModel>.Ok(organization.Adapt<OrganizationViewModel>())
                : Result<OrganizationViewModel>.NotFound();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to get organization {@Request}", request);
            return Result<OrganizationViewModel>.Internal("Failed to get organization");
        }
    }
}
