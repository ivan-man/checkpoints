using Hid.Checkpoint.Domain.Models;

namespace Hid.Checkpoint.DataAccess.Ef.Repositories.Implementations;

internal class PassRequestRepository : BaseRepositoryIdentity<CheckPointsContext, PassRequest, int>, IPassRequestRepository
{
    public PassRequestRepository(CheckPointsContext context) : base(context)
    {
    }
}
