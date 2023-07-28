using FluentValidation;

namespace Hid.Checkpoint.Business.Handlers.Organizations.EditContract;

public class EditOrganizationContractCommandValidator : AbstractValidator<EditOrganizationContractCommand>
{
    public EditOrganizationContractCommandValidator()
    {
        RuleFor(q => q.OrganizationContractId)
            .Must(q => q is > 0)
            .WithMessage("Invalid request");
        
        RuleFor(q => q.Description)
            .NotEmpty()
            .WithMessage($"Invalid {nameof(EditOrganizationContractCommand.Description)}");
        
        RuleFor(q => q.ValidTo)
            .Must(q => q >= DateTime.UtcNow.Date)
            .WithMessage($"Invalid {nameof(EditOrganizationContractCommand.ValidTo)}");
    }
}
