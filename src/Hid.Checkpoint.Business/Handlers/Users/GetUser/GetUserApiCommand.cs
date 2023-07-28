using Hid.CheckPoint.Shared;
using Hid.Identity.Common.Contracts;
using MediatR;

namespace Hid.Checkpoint.Business.Handlers.Users.GetUser;

public class GetUserApiCommand : IRequest<Result<UserContract?>>
{
    public int? PersonId { get; init; }
    public string? ExternalEmployeeId { get; init; }
}
