using Hid.CheckPoint.Shared;
using Hid.Identity.Business.InternalServices.Tokens;
using Hid.Identity.DataAccess.Ef;
using Hid.Identity.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TokenContract = Hid.Identity.Common.Contracts.TokenContract;

namespace Hid.Identity.Business.Handlers.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<TokenContract>>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly HidIdentityContext _dbContext;
    private readonly SignInManager<ApplicationUser> _signInManager;

    private readonly IJwtTokenManager _tokenManager;

    private readonly ILogger<LoginCommandHandler> _logger;

    public LoginCommandHandler(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IJwtTokenManager tokenManager,
        HidIdentityContext dbContext,
        ILogger<LoginCommandHandler> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenManager = tokenManager;
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<Result<TokenContract>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ApplicationUser? user = null;

            if (!string.IsNullOrWhiteSpace(request.Login))
                user = await _userManager.FindByNameAsync(request.Login)
                    .ConfigureAwait(false);

            if (request.UserId.HasValue && request.UserId != Guid.Empty)
                user = await _userManager.FindByIdAsync(request.UserId.ToString())
                    .ConfigureAwait(false);

            if (user == null)
            {
                request.ExternalEmployeeId = string.Empty;
                _logger.LogWarning("User not found {@Request}", request);
                return Result<TokenContract>.Forbidden("User not found");
            }

            if (!await _userManager.CheckPasswordAsync(user, request.ExternalEmployeeId).ConfigureAwait(false))
            {
                _logger.LogWarning("{UserId} provided invalid password", user.Id);
                return Result<TokenContract>.Bad("Invalid password");
            }

            var access = await _tokenManager.Generate(user, cancellationToken: cancellationToken);

            return Result<TokenContract>.Ok(new TokenContract
            {
                AccessToken = access.Token,
                Expired = access.Expired,
            });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to login");
            return Result<TokenContract>.Internal("Failed to login");
        }
    }
}
