using MediatR;

namespace Ecommerce.Application.Users.UserCommands.ChangePassword;

public class ChangePasswordCommand : IRequest<ChangePasswordResponse>
{
    public Guid UserId { get; set; }

    public string CurrentPassword { get; set; } = default!;

    public string NewPassword { get; set; } = default!;
}

public class ChangePasswordResponse
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = default!;
}