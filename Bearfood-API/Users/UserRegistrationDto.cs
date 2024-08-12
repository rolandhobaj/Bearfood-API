using Microsoft.IdentityModel.Tokens;

namespace Bearfood_API.Users;

public class UserRegistrationDto
{
    public string? FullName { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }

    public bool IsValid => !Username.IsNullOrEmpty() && !Password.IsNullOrEmpty();
}