using MediatR;

namespace Ecommerce.Application.Users.UserCommands.ForgotPassword;

public class ForgotPasswordCommand
    : IRequest<ForgotPasswordResponse>
{
    public string Email { get; set; } = default!;
}


public class ForgotPasswordResponse
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = default!;
}