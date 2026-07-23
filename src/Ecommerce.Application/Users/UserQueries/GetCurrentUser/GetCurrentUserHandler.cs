using Ecommerce.Domain.AggregateRootes.Users.IRepository;
using MediatR;

namespace Ecommerce.Application.Users.UserQueries.GetCurrentUser;

public class GetCurrentUserHandler(
    IUserRepository userRepository)
    : IRequestHandler<GetCurrentUserQuery, GetCurrentUserResponse>
{

    public async Task<GetCurrentUserResponse> Handle(
        GetCurrentUserQuery request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetById(request.UserId);

        if (user == null)
        {
            throw new Exception("User not found.");
        }


        return new GetCurrentUserResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Phone = user.Phone
        };
    }
}