using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Users.UserCommands.Register;
using Ecommerce.Domain.AggregateRootes.Users.Entities;
using Ecommerce.Domain.AggregateRootes.Users.IRepository;
using MediatR;
using BCrypt.Net;

public class RegisterHandler(
    IUserRepository userRepository,
    IEmailService emailService)
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
        request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = User.Create(
            request.Name,
            request.Phone,
            request.Email,
            request.Password
        );


        // Email Verification
        var verificationToken = Guid.NewGuid().ToString();

        user.VerificationToken = verificationToken;

        user.VerificationTokenExpiry =
            DateTime.UtcNow.AddHours(24);

        user.EmailVerified = false;


        await userRepository.Create(user);


        var verificationLink =
    $"https://localhost:7213/api/users/verify-email?token={verificationToken}";


        await emailService.SendVerificationEmailAsync(
            user.Email,
            verificationLink);


        return new RegisterResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Phone = user.Phone,
            Message = "Registration completed successfully. A verification email has been sent to your email address. Please verify your email before logging in."
        };
    }
}