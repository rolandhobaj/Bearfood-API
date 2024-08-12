using Microsoft.AspNetCore.Identity;

namespace Bearfood_API.Users;

public class User : IdentityUser
{
    public User() : base()
    {
        FullName = string.Empty;
    }

    public User(string userName, string fullName)
        : base(userName)
    {
        FullName = fullName;
    }

    public string FullName { get; set; }
}