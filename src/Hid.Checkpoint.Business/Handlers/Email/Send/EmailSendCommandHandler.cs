using System.Net;
using System.Net.Mail;
using Hid.Checkpoint.Business.Options;
using Hid.Checkpoint.DataAccess.Ef;
using Hid.Checkpoint.Domain.Models;
using Hid.CheckPoint.Shared;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Hid.Checkpoint.Business.Handlers.Email.Send;

public class EmailSendCommandHandler : IRequestHandler<EmailSendCommand, Result<Guid?>>
{
    private readonly IUnitOfWork _uow;
    private readonly EmailOptions _options;
    private readonly ILogger<EmailSendCommandHandler> _logger;

    public EmailSendCommandHandler(
        IOptions<EmailOptions> options, 
        ILogger<EmailSendCommandHandler> logger,
        IUnitOfWork uow)
    {
        _options = options.Value;
        _logger = logger;
        _uow = uow;
    }

    public async Task<Result<Guid?>> Handle(EmailSendCommand request, CancellationToken cancellationToken)
    {
        var email = request.Adapt<EmailItem>();
        email.EmailId = Guid.NewGuid();

        try
        {
            await _uow.Emails.AddAsync(email, cancellationToken);

            using (var client = GetClient())
            {
                using (var message = new MailMessage())
                {
                    message.Subject = request.Subject;
                    message.Body = request.Body;
                    request.To.ForEach(q => message.To.Add(q));
                    client.Send(message);
                }
            }

            email.Sent = true;
            
            return Result<Guid?>.Ok(email.EmailId);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to send email. {Id} {@Settings}", email.Id, _options);
            email.Sent = false;
            email.ErrorMessage = e.Message;
            return Result<Guid?>.Internal("Failed to send email.");
        }
        finally
        {
            await _uow.SaveChangesAsync(cancellationToken);
        }
    }


    private SmtpClient GetClient()
    {
        if (string.IsNullOrWhiteSpace(_options.ServerAddress)
            || _options.Port.HasValue != true
            || string.IsNullOrWhiteSpace(_options.Username)
            || string.IsNullOrWhiteSpace(_options.SystemEmail)
            || string.IsNullOrWhiteSpace(_options.Password))
        {
            throw new InvalidOperationException("Invalid email server settings");
        }

        var client = new SmtpClient(_options.ServerAddress, _options.Port!.Value);
        client.Credentials = new NetworkCredential(_options.SystemEmail, _options.Password);
        client.EnableSsl = _options.EnableSsl;
        client.DeliveryMethod = _options.DeliveryMethod ?? client.DeliveryMethod;
        client.UseDefaultCredentials = _options.UseDefaultCredentials;

        return client;
    }
}
