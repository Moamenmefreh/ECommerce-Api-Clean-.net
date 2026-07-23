using Ecommerce.Application.JWT;
using Ecommerce.Domain.AggregateRootes.Users.Repository;
using MediatR;

namespace Ecommerce.Application.Features.Authentication.Commands.Login;

public class LoginHandler(IUserRepository userRepository,
        IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, LoginResponse>
{

    public async Task<LoginResponse> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmail(request.Email);

        if (user == null)
        {
            throw new Exception("Invalid Email or Password");
        }

        // Password Verify هنا

        var roles = user.UserRoles
            .Select(ur => ur.Role.Name)
            .ToList();

        var token = jwtProvider.GenerateToken(user, roles);

        return new LoginResponse
        {
            Token = token,
            Name = user.Name,
            Email = user.Email
        };
    }
    }