using Hid.Checkpoint.Domain.Models;

namespace Hid.Checkpoint.DataAccess.Ef.Repositories.Implementations;

internal class OrganizationRepository : BaseRepositoryIdentity<CheckPointsContext, Organization, int>, IOrganizationRepository
{
    public OrganizationRepository(CheckPointsContext context) : base(context)
    {
    }
}
