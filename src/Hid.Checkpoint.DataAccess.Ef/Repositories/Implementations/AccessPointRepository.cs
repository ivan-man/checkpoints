using Hid.Checkpoint.Domain.Models;

namespace Hid.Checkpoint.DataAccess.Ef.Repositories.Implementations;

internal class AccessPointRepository : BaseRepositoryIdentity<CheckPointsContext, AccessPoint, int>, IAccessPointRepository
{
    public AccessPointRepository(CheckPointsContext context) : base(context)
    {
    }
}
