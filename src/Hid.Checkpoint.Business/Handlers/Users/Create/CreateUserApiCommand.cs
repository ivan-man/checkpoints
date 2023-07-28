using Hid.Checkpoint.Common.Enums;
using Hid.CheckPoint.Shared;
using MediatR;

namespace Hid.Checkpoint.Business.Handlers.Users.Create;

public class CreateUserApiCommand : IRequest<Result<Guid?>>
{
    public int PersonId { get; set; }
    public List<RoleFlags> Roles { get; set; }
}
