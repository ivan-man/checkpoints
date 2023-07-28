using Hid.CheckPoint.Shared;
using Hid.Identity.Common.Contracts;
using MediatR;

namespace Hid.Identity.Business.Handlers.Login;

public class LoginCommand : IRequest<Result<TokenContract>>
{
    public Guid? UserId { get; set; }
    public string? Login { get; set; }
    public string? ExternalEmployeeId { get; set; }
}
