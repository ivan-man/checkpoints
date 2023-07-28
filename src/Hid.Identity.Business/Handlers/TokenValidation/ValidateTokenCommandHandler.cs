using Hid.CheckPoint.Shared;
using Hid.Identity.Business.InternalServices.Tokens;
using MediatR;

namespace Hid.Identity.Business.Handlers.TokenValidation;

public class ValidateTokenCommandHandler : IRequestHandler<ValidateTokenCommand, Result>
{
    private readonly IJwtTokenManager _jwtTokenManager;

    public ValidateTokenCommandHandler(
        IJwtTokenManager jwtTokenManager)
    {
        _jwtTokenManager = jwtTokenManager;
    }

    public async Task<Result> Handle(ValidateTokenCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _jwtTokenManager.Validate(request.Token, cancellationToken)
            .ConfigureAwait(false);
        
        return validationResult;
    }
}
