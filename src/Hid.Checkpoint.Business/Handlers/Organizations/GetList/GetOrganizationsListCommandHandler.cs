using Hid.Checkpoint.Common.ViewModels;
using Hid.Checkpoint.DataAccess.Ef;
using Hid.CheckPoint.Shared.PaginationResult;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hid.Checkpoint.Business.Handlers.Organizations.GetList;

public class GetOrganizationsListCommandHandler : IRequestHandler<GetOrganizationsListCommand,
        PaginationResult<OrganizationViewModel>>
{
    private readonly CheckPointsContext _db;
    private readonly ILogger<GetOrganizationsListCommandHandler> _logger;

    public GetOrganizationsListCommandHandler(CheckPointsContext db, ILogger<GetOrganizationsListCommandHandler> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<PaginationResult<OrganizationViewModel>> Handle(GetOrganizationsListCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var predicate = request.GetPredicate();

            var total = await _db.Organizations.Where(predicate).CountAsync(cancellationToken: cancellationToken);
            if (total == 0)
                return PaginationResult<OrganizationViewModel>.NoContent();

            var query = _db.Organizations.Where(predicate);

            if (request is { PageSize: > 0, Page: > 0 })
            {
                query = query
                    .Skip(request.PageSize.Value * request.Page.Value)
                    .Take(request.PageSize.Value);
            }

            var organizations = await query.AsNoTracking()
                .Include(q => q.Contracts)
                .OrderByDescending(q => q.Created)
                .ProjectToType<OrganizationViewModel>()
                .ToListAsync(cancellationToken);

            return organizations.Any() 
                ? PaginationResult<OrganizationViewModel>.Ok(
                    organizations, 
                    request.PageSize ?? 0, 
                    request.Page ?? 0,
                    total)
                : PaginationResult<OrganizationViewModel>.NoContent();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to get organizations {@Request}", request);
            return PaginationResult<OrganizationViewModel>.Internal("Failed to get organizations");
        }
    }
}
