using MediatR;

namespace Ecommerce.Application.Features.Users.Commands.Register;

public class RegisterCommand : IRequest<RegisterResponse>
{
    public string Name { get; set; } = default!;

    public string Phone { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;
}
public class RegisterResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string Phone { get; set; } = default!;

    public string Message { get; set; } = default!;
}