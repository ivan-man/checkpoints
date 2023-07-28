using Hid.CheckPoint.Shared;
using Hid.Checkpoint.Common.Enums;
using MediatR;

namespace Hid.Identity.Business.Handlers.Users.Create;

public class CreateUserCommand : IRequest<Result<Guid?>>
{
    public string? UserName { get; init; }
    public int? PersonId { get; init; }
    public string ExternalEmployeeId { get; init; }
    public string? UserSecret { get; init; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public RoleFlags RolesValue { get; init; }
}
