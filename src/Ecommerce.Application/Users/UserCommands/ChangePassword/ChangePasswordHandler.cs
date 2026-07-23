using Ecommerce.Domain.AggregateRootes.Users.IRepository;
using BCrypt;
using MediatR;

namespace Ecommerce.Application.Users.UserCommands.ChangePassword;

public class ChangePasswordHandler(
    IUserRepository userRepository)
    : IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
{

    public async Task<ChangePasswordResponse> Handle(
        ChangePasswordCommand request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetById(request.UserId);

        if (user == null)
        {
            return new ChangePasswordResponse
            {
                IsSuccess = false,
                Message = "User not found."
            };
        }


        var isPasswordValid =
            BCrypt.Net.BCrypt.Verify(
                request.CurrentPassword,
                user.PasswordHash);


        if (!isPasswordValid)
        {
            return new ChangePasswordResponse
            {
                IsSuccess = false,
                Message = "Current password is incorrect."
            };
        }


        var newPasswordHash =
            BCrypt.Net.BCrypt.HashPassword(
                request.NewPassword);


        user.ChangePassword(newPasswordHash);

        await userRepository.ChangePassword(user);

        return new ChangePasswordResponse
        {
            IsSuccess = true,
            Message = "Password changed successfully."
        };
    }
}