using FluentValidation;

namespace Hid.Checkpoint.Business.Handlers.Email.Send;

public class EmailSendCommandValidator : AbstractValidator<EmailSendCommand>
{
    private const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    
    public EmailSendCommandValidator()
    {
        RuleFor(q => q.To)
            .NotEmpty()
            .WithMessage($"No addressees.");
        
        RuleForEach(q => q.To)
            .Matches(pattern)
            .WithMessage($"Any email is invalid.");
        
        RuleFor(q => q.Subject)
            .NotEmpty()
            .WithMessage($"No email subject.");
        
        RuleFor(q => q.Body)
            .NotEmpty()
            .WithMessage($"No email body.");
    }
}
