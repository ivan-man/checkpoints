using Hid.Checkpoint.Domain.Models;

namespace Hid.Checkpoint.DataAccess.Ef.Repositories.Implementations;

internal class DeviceRepository : BaseRepositoryIdentity<CheckPointsContext, Device, int>, IDeviceRepository
{
    public DeviceRepository(CheckPointsContext context) : base(context)
    {
    }
}
