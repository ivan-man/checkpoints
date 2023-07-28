using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Hid.CheckPoint.Shared;
using Hid.Checkpoint.Common.Enums;
using Hid.Identity.Common;
using Hid.Identity.Common.Consts;
using Hid.Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Hid.Identity.Business.InternalServices.Tokens;

internal class JwtTokenManager : IJwtTokenManager
{
    private readonly JwtOptions _options;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationUserRole> _roleManager;
    private readonly ILogger<JwtTokenManager> _logger;

    public JwtTokenManager(
        IOptions<JwtOptions> options,
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationUserRole> roleManager,
        ILogger<JwtTokenManager> logger)
    {
        _options = options.Value;
        _userManager = userManager;
        _roleManager = roleManager;
        _logger = logger;
    }

    public async Task<TokenModel> Generate(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_options.Secret ?? string.Empty);
        var roles = await GetUserRolesAsync(user, cancellationToken)
            .ConfigureAwait(false);

        var rolesValue = roles.Aggregate(RoleFlags.None, (current, role) => current | role.Role);
        
        var claims = new List<Claim>
        {
            new(ApplicationClaims.UserId, user.Id.ToString()),
            new(ApplicationClaims.ExtEmployeeId, user.ExternalEmployeeId),
            new(ApplicationClaims.RolesAggregated, ((int)rolesValue).ToString()),
            new(ApplicationClaims.EmployeeId, user.PersonId.ToString()),
            new(ApplicationClaims.Jti, Guid.NewGuid().ToString()),
            new(ApplicationClaims.Iat, $"{DateTime.UtcNow.ToUnix()}"),
        };

        claims.AddRange(roles.Select(e => new Claim(ClaimTypes.Role, e.ToString())));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = ApplicationClaims.Issuer,
            Expires = DateTime.UtcNow.AddMinutes(_options.AccessTtl),

            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),

            AdditionalHeaderClaims = new Dictionary<string, object>
                { { "subType", "bearer" } },

            Subject = new ClaimsIdentity(claims),
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = jwtTokenHandler.WriteToken(token);

        return new TokenModel
        {
            Id = token.Id,
            Token = jwtToken
        };
    }

    public Task<Result> Validate(string token, CancellationToken cancellationToken = default)
    {
        Claim? userIdClaim = null;

        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_options.Secret ?? string.Empty);

        try
        {
            var jsonToken = jwtTokenHandler.ReadToken(token);
            if (jsonToken is not JwtSecurityToken tokenS)
            {
                return Task.FromResult((Result.Bad("Provided token is not JWT")));
            }

            userIdClaim = tokenS.Claims.First(e => e.Type == ApplicationClaims.UserId);

            jwtTokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                ValidateLifetime = false, //ToDo
                RequireSignedTokens = true,
                ValidIssuer = ApplicationClaims.Issuer,
                RequireExpirationTime = false, //ToDo
            }, out var validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == ApplicationClaims.UserId).Value);

            return Task.FromResult(
                userId != Guid.Empty && (DateTime.UtcNow - jwtToken.IssuedAt).TotalSeconds < _options.AccessTtl * 60
                    ? Result.Ok()
                    : Result.UnAuthorized("User id is not valid"));
        }
        catch (ArgumentException e)
        {
            _logger.LogWarning(e, "JWT does not contain 'id' claim");

            return Task.FromResult(Result.Bad("JWT does not contain required claims"));
        }
        catch (SecurityTokenExpiredException e)
        {
            _logger.LogWarning(e, "Provided token Expired. UserId: {Claim}", userIdClaim?.Value);
            return Task.FromResult(Result.Forbidden("Token expired"));
        }
        catch (Exception e)
        {
            _logger.LogWarning(e, "Provided token is not valid. UserId: {Claim}", userIdClaim?.Value);
            return Task.FromResult(Result.Validation("Token is not valid"));
        }
    }
    
    private async Task<List<ApplicationUserRole>> GetUserRolesAsync(
        ApplicationUser user, 
        CancellationToken cancellationToken = default)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        var userRoleIds = await _userManager.GetRolesAsync(user);

        var userRoles = new List<ApplicationUserRole>();
        foreach (var roleId in userRoleIds)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role != null)
            {
                userRoles.Add(role);
            }
        }

        return userRoles;
    }
}
