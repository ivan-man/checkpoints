using Hid.Checkpoint.Domain.Models;

namespace Hid.Checkpoint.DataAccess.Ef.Repositories.Implementations;

internal class AccessLevelRepository : BaseRepositoryIdentity<CheckPointsContext, AccessLevel, int>, IAccessLevelRepository
{
    public AccessLevelRepository(CheckPointsContext context) : base(context)
    {
    }
}
