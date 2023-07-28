using Hid.Checkpoint.Common.Enums;
using Hid.CheckPoint.Shared;
using MediatR;

namespace Hid.Identity.Business.Handlers.Roles.RemoveUserRole;

public class RemoveUserRoleCommand : IRequest<Result>
{
    public int? PersonId { get; init; }
    public Guid? UserId { get; init; }
    public string? ExternalEmployeeId { get; init; }
    public RoleFlags RoleValue { get; init; }
}
