using FluentValidation;

namespace Hid.Identity.Business.Handlers.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty()
            .When(q => !q.UserId.HasValue || q.UserId.Value == default)
            .WithMessage($"{nameof(LoginCommand.UserId)} and {nameof(LoginCommand.Login)} are empty");
        
        RuleFor(x => x.UserId)
            .NotEmpty()
            .When(q => string.IsNullOrWhiteSpace(q.ExternalEmployeeId))
            .WithMessage($"{nameof(LoginCommand.UserId)} and {nameof(LoginCommand.Login)} are empty");

        RuleFor(x => x.ExternalEmployeeId)
            .NotEmpty()
            .WithMessage($"Invalid {nameof(LoginCommand.ExternalEmployeeId)}");
    }
}
