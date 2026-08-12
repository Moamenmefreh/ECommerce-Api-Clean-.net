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
        await SendEmailAsync(
            email,
            "Verify Email",
            $"Click <a href='{verificationLink}'>here</a> to verify your email.");
    }



    public async Task SendEmailAsync(
        string email,
        string subject,
        string body)
    {
        var message = new MimeMessage();


        message.From.Add(
            MailboxAddress.Parse(_settings.Email));


        message.To.Add(
            MailboxAddress.Parse(email));


        message.Subject = subject;


        message.Body = new TextPart("html")
        {
            Text = body
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