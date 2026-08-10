using Ecommerce.Application.Features.Users.Commands.Register;
using Ecommerce.Domain.AggregateRootes.Users.Entities;
using Ecommerce.Domain.AggregateRootes.Users.Repository;
using MediatR;

public class RegisterHandler(IUserRepository userRepository)
    : IRequestHandler<RegisterCommand, RegisterResponse>
{
   


    public async Task<RegisterResponse> Handle(
        RegisterCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await userRepository
            .GetByEmail(request.Email);

        if (existingUser != null)
        {
            throw new Exception("Email already exists");
        }


        var user = User.Create(
            request.Name,
            request.Phone,
            request.Email,
            request.Password
        );


        await userRepository.Create(user);


        return new RegisterResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Phone = user.Phone,
            Message = "User registered successfully"
        };
    }
}