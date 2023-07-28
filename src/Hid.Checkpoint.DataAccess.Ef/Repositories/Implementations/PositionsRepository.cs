using Hid.Checkpoint.Domain.Models;

namespace Hid.Checkpoint.DataAccess.Ef.Repositories.Implementations;

internal class PositionsRepository : BaseRepositoryIdentity<CheckPointsContext, Position, int>, IPositionsRepository
{
    public PositionsRepository(CheckPointsContext context) : base(context)
    {
    }
}
