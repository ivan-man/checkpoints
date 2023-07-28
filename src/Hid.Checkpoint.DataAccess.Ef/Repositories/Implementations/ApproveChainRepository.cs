using Hid.Checkpoint.Domain.Models;

namespace Hid.Checkpoint.DataAccess.Ef.Repositories.Implementations;

internal class ApproveChainRepository : BaseRepositoryIdentity<CheckPointsContext, ApproveChain, int>, IApproveChainRepository
{
    public ApproveChainRepository(CheckPointsContext context) : base(context)
    {
    }
}
