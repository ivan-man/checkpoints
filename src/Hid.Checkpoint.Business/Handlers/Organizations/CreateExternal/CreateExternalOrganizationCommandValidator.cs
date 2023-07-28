using FluentValidation;

namespace Hid.Checkpoint.Business.Handlers.Organizations.CreateExternal;

public class CreateExternalOrganizationCommandValidator : AbstractValidator<CreateExternalOrganizationCommand>
{
    public CreateExternalOrganizationCommandValidator()
    {
        RuleFor(q => q.Name)
            .NotEmpty()
            .WithMessage($"Empty name.");
    }
}
