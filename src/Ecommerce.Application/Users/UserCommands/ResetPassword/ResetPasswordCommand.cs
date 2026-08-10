using MediatR;

namespace Ecommerce.Application.Users.UserCommands.ResetPassword;

public class ResetPasswordCommand : IRequest<ResetPasswordResponse>
{
    public string Token { get; set; } = default!;

    public string NewPassword { get; set; } = default!;
}
public class ResetPasswordResponse
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = default!;
}