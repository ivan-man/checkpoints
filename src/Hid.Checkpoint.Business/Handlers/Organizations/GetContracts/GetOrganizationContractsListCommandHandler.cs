using Hid.Checkpoint.Common.ViewModels;
using Hid.Checkpoint.DataAccess.Ef;
using Hid.CheckPoint.Shared;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hid.Checkpoint.Business.Handlers.Organizations.GetContracts;

public class GetOrganizationContractsListCommandHandler 
    : IRequestHandler<GetOrganizationContractsListCommand, ResultList<OrganizationContractViewModel>>
{
    private readonly CheckPointsContext _db;
    private readonly ILogger<GetOrganizationContractsListCommandHandler> _logger;

    public GetOrganizationContractsListCommandHandler(CheckPointsContext db, ILogger<GetOrganizationContractsListCommandHandler> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<ResultList<OrganizationContractViewModel>> Handle(GetOrganizationContractsListCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var todayDate = DateOnly.FromDateTime(DateTime.Today.Date);

            var contracts = await _db.OrganizationContracts
                .AsNoTracking()
                .Where(q => !q.Removed
                            && q.OrganizationId == request.OrganizationId
                            && (q.ValidTo <= todayDate || q.ValidTo == null))
                .ProjectToType<OrganizationContractViewModel>()
                .ToListAsync(cancellationToken);

            return contracts.Any()
                ? ResultList<OrganizationContractViewModel>.Ok(contracts)
                : ResultList<OrganizationContractViewModel>.NoContent();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to get contracts");
            return ResultList<OrganizationContractViewModel>.Internal("Failed to get contracts");
        }
    }
}
