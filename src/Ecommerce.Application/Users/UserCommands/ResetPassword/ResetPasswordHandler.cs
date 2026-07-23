using BCrypt.Net;
using Ecommerce.Domain.AggregateRootes.Users.IRepository;
using MediatR;

namespace Ecommerce.Application.Users.UserCommands.ResetPassword;

public class ResetPasswordHandler(
    IUserRepository userRepository)
    : IRequestHandler<ResetPasswordCommand, ResetPasswordResponse>
{
    public async Task<ResetPasswordResponse> Handle(
        ResetPasswordCommand request,
        CancellationToken cancellationToken)
    {
        var user =
            await userRepository.GetByPasswordResetToken(request.Token);

        if (user == null)
        {
            return new ResetPasswordResponse
            {
                IsSuccess = false,
                Message = "Invalid token."
            };
        }

        if (user.PasswordResetTokenExpiry < DateTime.UtcNow)
        {
            return new ResetPasswordResponse
            {
                IsSuccess = false,
                Message = "Token has expired."
            };
        }

        var hashedPassword =
            BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

        user.ResetPassword(hashedPassword);

        await userRepository.Update(user);

        return new ResetPasswordResponse
        {
            IsSuccess = true,
            Message = "Password has been reset successfully."
        };
    }
}