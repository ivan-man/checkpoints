using FluentValidation;

namespace Hid.Checkpoint.Business.Handlers.Users.GetUser;

public class GetUserApiCommandValidator : AbstractValidator<GetUserApiCommand>
{
    public GetUserApiCommandValidator()
    {
        RuleFor(q => q.PersonId)
            .NotEmpty()
            .When(q => string.IsNullOrWhiteSpace(q.ExternalEmployeeId))
            .WithMessage($"Invalid request.");
        
        RuleFor(q => q.ExternalEmployeeId)
            .NotEmpty()
            .When(q => !q.PersonId.HasValue)
            .WithMessage($"Invalid request.");
    }
}
