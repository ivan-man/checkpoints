using FluentValidation;

namespace Hid.Identity.Business.Handlers.TokenValidation;

public class ValidateTokenCommandValidator : AbstractValidator<ValidateTokenCommand>
{
    public ValidateTokenCommandValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty()
            .WithMessage("Token is empty");
    }
}
