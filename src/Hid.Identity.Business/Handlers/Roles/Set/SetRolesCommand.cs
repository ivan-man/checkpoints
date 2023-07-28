using Hid.Checkpoint.Common.Enums;
using Hid.CheckPoint.Shared;
using MediatR;

namespace Hid.Identity.Business.Handlers.Roles.Set;

public class SetRolesCommand : IRequest<Result>
{
    public int? EmployeeId { get; init; }
    public Guid? UserId { get; init; }
    public string? ExternalEmployeeId { get; init; }
    public RoleFlags RolesValue { get; init; }
}
