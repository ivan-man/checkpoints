using FluentValidation;

namespace Hid.Checkpoint.Business.Handlers.Organizations.Get;

public class GetOrganizationCommandValidator : AbstractValidator<GetOrganizationCommand>
{
    public GetOrganizationCommandValidator()
    {
        RuleFor(q => q.Id)
            .Must(q => q is > 0)
            .When(q => !q.ExternalId.HasValue || q.ExternalId.Value == default)
            .WithMessage("Invalid request");

        RuleFor(q => q.ExternalId)
            .NotEmpty()
            .When(q => !q.Id.HasValue)
            .WithMessage("Invalid request");
    }
}
