using Hid.Checkpoint.Common.Enums;

namespace Hid.Identity.Common.Models;

public interface IUser
{
    public Guid Id { get; }
    public int PersonId { get; }
    public string ExternalEmployeeId { get; }
    public RoleFlags RolesValue { get; }

    public List<RoleFlags>? RolesView { get; }
    public List<string>? RolesDisplay { get; }
}
