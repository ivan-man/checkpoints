using FluentValidation;

namespace Hid.Identity.Business.Handlers.Users.GetUser;

public class GetUserCommandValidator : AbstractValidator<GetUserCommand>
{
    public GetUserCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .When(q => string.IsNullOrWhiteSpace(q.Email)
                       && string.IsNullOrWhiteSpace(q.PhoneNumber)
                       && string.IsNullOrWhiteSpace(q.ExternalEmployeeId)
                       && !q.PersonId.HasValue);

        RuleFor(x => x.Email)
            .NotEmpty()
            .When(q => string.IsNullOrWhiteSpace(q.UserName)
                       && string.IsNullOrWhiteSpace(q.PhoneNumber)
                       && string.IsNullOrWhiteSpace(q.ExternalEmployeeId)
                       && !q.PersonId.HasValue);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .When(q => string.IsNullOrWhiteSpace(q.Email)
                       && string.IsNullOrWhiteSpace(q.UserName)
                       && string.IsNullOrWhiteSpace(q.ExternalEmployeeId)
                       && !q.PersonId.HasValue);

        RuleFor(x => x.ExternalEmployeeId)
            .NotEmpty()
            .When(q => string.IsNullOrWhiteSpace(q.Email)
                       && string.IsNullOrWhiteSpace(q.PhoneNumber)
                       && string.IsNullOrWhiteSpace(q.UserName)
                       && !q.PersonId.HasValue);

        RuleFor(x => x.PersonId)
            .NotEmpty()
            .When(q => string.IsNullOrWhiteSpace(q.Email)
                       && string.IsNullOrWhiteSpace(q.PhoneNumber)
                       && string.IsNullOrWhiteSpace(q.ExternalEmployeeId)
                       && string.IsNullOrWhiteSpace(q.UserName));
    }
}
