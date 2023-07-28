using Hid.CheckPoint.Shared;
using Hid.Identity.Common.Contracts;
using MediatR;

namespace Hid.Identity.Business.Handlers.Users.GetUser;

public class GetUserCommand : IRequest<Result<UserContract?>>
{
    public string? UserName { get; init; }
    public int? PersonId { get; init; }
    public string? ExternalEmployeeId { get; init; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
}
