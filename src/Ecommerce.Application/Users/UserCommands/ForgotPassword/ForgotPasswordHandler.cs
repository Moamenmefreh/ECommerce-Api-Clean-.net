using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.AggregateRootes.Users.IRepository;
using MediatR;

namespace Ecommerce.Application.Users.UserCommands.ForgotPassword;

public class ForgotPasswordHandler(
    IUserRepository userRepository,
    IEmailService emailService)
    : IRequestHandler<ForgotPasswordCommand, ForgotPasswordResponse>
{
    public async Task<ForgotPasswordResponse> Handle(
        ForgotPasswordCommand request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmail(request.Email);

        // لا نكشف إذا كان الإيميل موجود أم لا
        if (user == null)
        {
            return new ForgotPasswordResponse
            {
                IsSuccess = true,
                Message = "If this email exists, a reset link has been sent."
            };
        }


        // Generate Reset Token
        user.GeneratePasswordResetToken();


        // Save changes
        await userRepository.Update(user);


        // Create Reset Link
        var resetLink =
            $"https://localhost:7213/api/Users/reset-password?token={user.PasswordResetToken}";


        // Send Email
        await emailService.SendEmailAsync(
            user.Email!,
            "Reset Password",
            $@"
            <h2>Password Reset</h2>
            <p>You requested to reset your password.</p>

            <p>
                Click the link below to reset your password:
            </p>

            <a href='{resetLink}'>
                Reset Password
            </a>

            <p>
                This link will expire after 1 hour.
            </p>
            ");


        return new ForgotPasswordResponse
        {
            IsSuccess = true,
            Message = "If this email exists, a reset link has been sent."
        };
    }
}