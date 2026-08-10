namespace Ecommerce.Application.Interfaces;

public interface IEmailService
{

   public Task SendVerificationEmailAsync(
        string email,
        string verificationLink);

}