using System.Net;
using System.Net.Mail;
using Library.Application.Email;
using Library.Application.Interfaces;

namespace Library.Infrastructure.Email;

public class SmtpEmailService : IEmailService
{
    private readonly EmailSettings _settings;

    public SmtpEmailService(EmailSettings settings)
    {
        _settings = settings;
    }

    public async Task SendAsync(string to, string subject, string body, bool isHtml = true, CancellationToken cancellationToken = default)
    {
        using var message = new MailMessage(_settings.From, to, subject, body)
        {
            IsBodyHtml = isHtml
        };

        using var client = new SmtpClient(_settings.Host, _settings.Port)
        {
            EnableSsl = _settings.EnableSsl,
            Credentials = new NetworkCredential(_settings.Username, _settings.Password)
        };

        await client.SendMailAsync(message, cancellationToken);
    }
}
