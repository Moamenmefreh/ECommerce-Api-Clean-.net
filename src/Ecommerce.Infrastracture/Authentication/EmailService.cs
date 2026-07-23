using Ecommerce.Application.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Ecommerce.Infrastructure.Authentication;

public class EmailService : IEmailService
{
    private readonly EmailSettings _settings;

    public EmailService(IOptions<EmailSettings> options)
    {
        _settings = options.Value;
    }


    public async Task SendVerificationEmailAsync(
        string email,
        string verificationLink)
    {
        var message = new MimeMessage();
        Console.WriteLine($"Email From: '{_settings.Email}'");
        message.From.Add(
            MailboxAddress.Parse(_settings.Email));

        message.To.Add(
            MailboxAddress.Parse(email));

        message.Subject = "Verify Email";

        message.Body = new TextPart("html")
        {
            Text =
            $"Click <a href='{verificationLink}'>here</a> to verify your email."
        };


        using var smtp = new SmtpClient();

        await smtp.ConnectAsync(
            _settings.Host,
            _settings.Port,
            SecureSocketOptions.StartTls);


        await smtp.AuthenticateAsync(
            _settings.UserName,
            _settings.Password);


        await smtp.SendAsync(message);


        await smtp.DisconnectAsync(true);
    }
}