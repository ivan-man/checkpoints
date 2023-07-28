using Hid.Checkpoint.Domain.Models;

namespace Hid.Checkpoint.DataAccess.Ef.Repositories.Implementations;

internal class CustomizablePropertyRepository : BaseRepositoryIdentity<CheckPointsContext, CustomizableProperty, string>, ICustomizablePropertyRepository
{
    public CustomizablePropertyRepository(CheckPointsContext context) : base(context)
    {
    }
}
