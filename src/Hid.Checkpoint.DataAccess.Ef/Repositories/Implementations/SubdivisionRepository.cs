using Hid.Checkpoint.Domain.Models;

namespace Hid.Checkpoint.DataAccess.Ef.Repositories.Implementations;

internal class SubdivisionRepository : BaseRepositoryIdentity<CheckPointsContext, Subdivision, int>, ISubdivisionRepository
{
    public SubdivisionRepository(CheckPointsContext context) : base(context)
    {
    }
}
