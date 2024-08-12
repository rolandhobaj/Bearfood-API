using Microsoft.IdentityModel.Tokens;

namespace Bearfood_API.Users;

public class LoginDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public bool IsValid => !Username.IsNullOrEmpty() && !Password.IsNullOrEmpty();
}