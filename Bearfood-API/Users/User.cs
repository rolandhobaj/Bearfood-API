using Microsoft.AspNetCore.Identity;

namespace Bearfood_API.Users;

public class User : IdentityUser
{
    public string FullName { get; set; }
}