using Ecommerce.Domain.AggregateRootes.Users.IRepository;

using MediatR;

namespace Ecommerce.Application.Users.UserQueries.VerifyEmail;

public class VerifyEmailHandler(IUserRepository userRepository) : IRequestHandler<VerifyEmailCommand, VerfiyEmailCommandResponse>
{
    public async Task<VerfiyEmailCommandResponse> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await userRepository.GetByVerificationTokenAsync(request.Token);
            if (user == null)
                return new VerfiyEmailCommandResponse
                {
                    IsSuccess = false,
                    Message = "Invalid or expired token."
                };

            user.EmailVerified = true;


            await userRepository.Update(user);

            return new VerfiyEmailCommandResponse
            {
                IsSuccess = true,
                Message = "Email verified successfully."
            };


        }
        catch (Exception ex)
        {
            return new VerfiyEmailCommandResponse
            {
                IsSuccess = false,
                Message = $"An error occurred: {ex.Message}"
            };
        }
    }

   
}