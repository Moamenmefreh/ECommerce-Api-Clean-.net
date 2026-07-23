using MediatR;

namespace Ecommerce.Application.Users.UserQueries.GetCurrentUser;

public class GetCurrentUserQuery : IRequest<GetCurrentUserResponse>
{
    public Guid UserId { get; set; }
}


public class GetCurrentUserResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string Phone { get; set; } = default!;
}