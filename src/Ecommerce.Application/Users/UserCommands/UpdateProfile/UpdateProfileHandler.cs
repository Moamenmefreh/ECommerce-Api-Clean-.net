using Ecommerce.Domain.AggregateRootes.Users.IRepository;
using MediatR;

namespace Ecommerce.Application.Users.UserCommands.UpdateProfile;

public class UpdateProfileHandler(IUserRepository userRepository)
    : IRequestHandler<UpdateProfileCommand, UpdateProfileResponse>
{
    public async Task<UpdateProfileResponse> Handle(
        UpdateProfileCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var user =await userRepository.GetById(request.UserId);

            if (user is null)
            {
                return new UpdateProfileResponse
                {
                    IsSuccess = false,
                    Message = "User not found."
                };
            }

            user.Update(
                request.Name,
                request.Phone);

           await userRepository.Update(user);

            return new UpdateProfileResponse
            {
                IsSuccess = true,
                Message = "Profile updated successfully."
            };
        }
        catch (Exception ex)
        {
            return new UpdateProfileResponse
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }
}