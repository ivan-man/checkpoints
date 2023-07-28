using Hid.CheckPoint.Shared;
using Hid.Identity.Common;
using Hid.Identity.Domain.Models;

namespace Hid.Identity.Business.InternalServices.Tokens;

public interface IJwtTokenManager
{
    Task<TokenModel> Generate(ApplicationUser user, CancellationToken cancellationToken = default);
    Task<Result> Validate(string token, CancellationToken cancellationToken = default);
}
