using FluentValidation;

namespace Hid.Checkpoint.Business.Handlers.Organizations.GetContracts;

public class GetOrganizationContractsListCommandValidator : AbstractValidator<GetOrganizationContractsListCommand>
{
    public GetOrganizationContractsListCommandValidator()
    {
        RuleFor(q => q.OrganizationId)
            .Must(q => q is > 0)
            .WithMessage("Invalid request");
    }
}
