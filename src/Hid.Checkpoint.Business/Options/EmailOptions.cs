using System.Net.Mail;

namespace Hid.Checkpoint.Business.Options;

public class EmailOptions
{
    public string? Username  { get; set; }
    public string? Password  { get; set; }
    public string? SystemEmail  { get; set; }
    public string? ServerAddress { get; set; }
    public int? Port { get; set; }
    public bool EnableSsl { get; set; } = false;
    public SmtpDeliveryMethod? DeliveryMethod { get; set; } = SmtpDeliveryMethod.Network;
    public bool UseDefaultCredentials { get; set; } = false;
    
    // private bool? _useSmtp;
    //
    // public bool UseSmtp
    // {
    //     get => _useSmtp ?? false;
    //     set
    //     {
    //         if (value && string.IsNullOrWhiteSpace(SmtpOptions?.ServerAddress))
    //             throw new InvalidCredentialException($"Invalid {nameof(SmtpOptions)}");
    //
    //         _useSmtp = value;
    //     }
    // }
    //
    // private bool? _usePop;
    //
    // public bool UsePop
    // {
    //     get => _usePop ?? false;
    //     set
    //     {
    //         if (value && string.IsNullOrWhiteSpace(PopOptions?.ServerAddress))
    //             throw new InvalidCredentialException($"Invalid {nameof(PopOptions)}");
    //
    //         _usePop = value;
    //     }
    // }
    //
    // public PopOptions? PopOptions { get; set; }
    // public SmtpOptions? SmtpOptions { get; set; }
}
