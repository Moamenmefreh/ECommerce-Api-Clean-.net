using MediatR;

public class LoginCommand : IRequest<LoginResponse>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
public class LoginResponse
{
    public string Token { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
}