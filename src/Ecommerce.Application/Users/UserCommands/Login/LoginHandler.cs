using Ecommerce.Application.JWT;
using Ecommerce.Domain.AggregateRootes.Users.IRepository;
using MediatR;
using System.Xml.Linq;

namespace Ecommerce.Application.Features.Authentication.Commands.Login;

public class LoginHandler(
    IUserRepository userRepository,
    IJwtProvider jwtProvider)
    : IRequestHandler<LoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmail(request.Email);

        if (user == null)
        {
            throw new Exception("Invalid email or password.");
        }


        // تحقق من كلمة المرور هنا
        if (!BCrypt.Net.BCrypt.Verify(request.Password,user.PasswordHash))
        {
            throw new Exception("Invalid Email or Password");
        }
        if (!user.EmailVerified)
        {
            return new LoginResponse
            {
                Token = "token",
                Name = user.Name,
                Email = "Your email address has not been verified." +
                " Please check your inbox and verify your email before logging in."
            };
           
        }

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