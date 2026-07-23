namespace Ecommerce.Infrastructure.Authentication;

public class EmailSettings
{
    public string Email { get; set; } = string.Empty;

    public string Host { get; set; } = default!;

    public int Port { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}