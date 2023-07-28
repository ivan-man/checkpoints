using Hid.Checkpoint.Domain.Models;

namespace Hid.Checkpoint.DataAccess.Ef.Repositories.Implementations;

internal class CountryRepository : BaseRepositoryIdentity<CheckPointsContext, Country, int>, ICountryRepository
{
    public CountryRepository(CheckPointsContext context) : base(context)
    {
    }
}
