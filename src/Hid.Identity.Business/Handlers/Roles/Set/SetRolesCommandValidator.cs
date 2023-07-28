using FluentValidation;

namespace Hid.Identity.Business.Handlers.Roles.Set;

public class SetRolesCommandValidator : AbstractValidator<SetRolesCommand>
{
    public SetRolesCommandValidator()
    {
        RuleFor(x => x.EmployeeId)
            .NotEmpty()
            .When(q => (!q.UserId.HasValue || q.UserId.Value == default) 
                       && string.IsNullOrWhiteSpace(q.ExternalEmployeeId))
            .WithMessage("Invalid request");
        
        RuleFor(x => x.UserId)
            .NotEmpty()
            .When(q => q.EmployeeId is null or default(int) 
                       && string.IsNullOrWhiteSpace(q.ExternalEmployeeId))
            .WithMessage("Invalid request");
        
        RuleFor(x => x.ExternalEmployeeId)
            .NotEmpty()
            .When(q => q.EmployeeId is null or default(int)
                       && (!q.UserId.HasValue || q.UserId.Value == default))
            .WithMessage("Invalid request");
    }
}
