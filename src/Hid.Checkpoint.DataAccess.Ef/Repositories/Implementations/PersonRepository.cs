using Hid.Checkpoint.Domain.Models;

namespace Hid.Checkpoint.DataAccess.Ef.Repositories.Implementations;

internal class PersonRepository : BaseRepositoryIdentity<CheckPointsContext, Person, int>, IPersonRepository
{
    public PersonRepository(CheckPointsContext context) : base(context)
    {
    }
}
