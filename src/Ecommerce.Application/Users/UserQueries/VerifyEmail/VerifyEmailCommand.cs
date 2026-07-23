using MediatR;

namespace Ecommerce.Application.Users.UserQueries.VerifyEmail;

public class VerifyEmailCommand : IRequest<VerfiyEmailCommandResponse>
{
    public string Token { get; set; } = default!;
}
public class VerfiyEmailCommandResponse
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}