using Hid.Checkpoint.Common.Enums;
using Hid.CheckPoint.Shared;
using Hid.Identity.Domain.Models;
using MediatR;

namespace Hid.Identity.Business.Handlers.Roles.CreateIfNotExists;

public class CreateRoleIfNotExistsCommand : IRequest<Result<ApplicationUserRole>>
{
    public RoleFlags Role { get; set; }
}
