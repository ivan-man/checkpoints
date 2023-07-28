using Hid.CheckPoint.Shared.PaginationResult;
using Hid.Identity.Common.Models;
using MediatR;

namespace Hid.Identity.Business.Handlers.Users.GetUsersList;

public class GetUsersListCommand : IRequest<PaginationResult<IUser>>
{
    
}
