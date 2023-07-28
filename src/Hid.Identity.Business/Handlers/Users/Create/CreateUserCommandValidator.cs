using FluentValidation;

namespace Hid.Identity.Business.Handlers.Users.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage($"{nameof(CreateUserCommand.UserName)} is empty");

        RuleFor(x => x.PersonId)
            .NotEmpty()
            .WithMessage($"Invalid {nameof(CreateUserCommand.PersonId)}");

        RuleFor(x => x.ExternalEmployeeId)
            .NotEmpty()
            .WithMessage($"Invalid {nameof(CreateUserCommand.ExternalEmployeeId)}");

        RuleFor(x => x.RolesValue)
            .Must(q => (int)q >= 0)
            .WithMessage($"Invalid {nameof(CreateUserCommand.RolesValue)}");
    }
}
