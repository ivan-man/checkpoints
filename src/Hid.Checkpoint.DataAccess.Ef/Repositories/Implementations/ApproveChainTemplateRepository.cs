using Hid.Checkpoint.Domain.Models;

namespace Hid.Checkpoint.DataAccess.Ef.Repositories.Implementations;

internal class ApproveChainTemplateRepository : BaseRepositoryIdentity<CheckPointsContext, ChainTemplate, int>, IApproveChainTemplateRepository
{
    public ApproveChainTemplateRepository(CheckPointsContext context) : base(context)
    {
    }
}
