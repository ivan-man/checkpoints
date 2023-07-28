using Hid.Checkpoint.Common.Enums;
using Hid.Identity.Common.Models;

namespace Hid.Identity.Client.Services;

public interface ICurrentUserService
{
    ICurrentUser? GetCurrentUser();
    bool HasAnyPermissions(params RoleFlags[] roles);
}
