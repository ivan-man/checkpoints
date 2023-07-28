using System.IdentityModel.Tokens.Jwt;
using Hid.CheckPoint.Shared;
using Hid.Checkpoint.Common.Enums;
using Hid.Identity.Common.Consts;
using Hid.Identity.Common.Contracts;
using Hid.Identity.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Hid.Identity.Client.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public CurrentUserService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
    }

    public virtual bool HasAnyPermissions(params RoleFlags[] roles)
    {
        var user = GetCurrentUser();
        return user is not null && roles.Any(role => user.RolesValue.HasFlag(role));
    }
    
    public virtual ICurrentUser? GetCurrentUser()
    {
        var jwt = GetJwtFromHttpContext();
        if (string.IsNullOrWhiteSpace(jwt))
            return null;
        
        var jwtData = ReadJwtToken(jwt);

        return jwtData;
    }

    private string? GetJwtFromHttpContext()
    {
        StringValues authHeader = string.Empty;
        
        if (!_contextAccessor.HttpContext?.Request.Headers.TryGetValue("Authorization", out authHeader) ?? false)
            _contextAccessor.HttpContext?.Request.Query.TryGetValue("access_token", out authHeader);

        return string.IsNullOrWhiteSpace(authHeader.ToString())
            ? null
            : authHeader.ToString().Split(' ').LastOrDefault();
    }

    private static ICurrentUser? ReadJwtToken(string jwt)
    {
        if (string.IsNullOrWhiteSpace(jwt))
            throw new ArgumentNullException(nameof(jwt));

        var token = new JwtSecurityTokenHandler().ReadJwtToken(jwt);

        var id = token.Claims.FirstOrDefault(x => x.Type.Equals(ApplicationClaims.UserId))?.Value;
        var personId = token.Claims.FirstOrDefault(x => x.Type.Equals(ApplicationClaims.EmployeeId))?.Value;
        var extEmployeeId = token.Claims.FirstOrDefault(x => x.Type.Equals(ApplicationClaims.ExtEmployeeId))?.Value;
        var role = token.Claims.FirstOrDefault(x => x.Type.Equals(ApplicationClaims.RolesAggregated))?.Value;
        var login = token.Claims.FirstOrDefault(x => x.Type.Equals(ApplicationClaims.Login))?.Value;
        var jti = token.Claims.FirstOrDefault(x => x.Type.Equals(ApplicationClaims.Jti))?.Value;
        var iat = token.Claims.FirstOrDefault(x => x.Type.Equals(ApplicationClaims.Iat))?.Value;

        return !Guid.TryParse(id, out var userId)
            ? null
            : new CurrentUserContract
            {
                Id =  userId,
                PersonId = personId.ParseIntSafe() ?? -1,
                RolesValue = (RoleFlags)(role.ParseIntSafe() ?? 0),
                Login = login,
                ExternalEmployeeId = extEmployeeId,
                Jti = jti.ParseGuidSafe(),
                Iat = iat.ParseLongSafe()?.FromUnix(),
            };
    }
}
