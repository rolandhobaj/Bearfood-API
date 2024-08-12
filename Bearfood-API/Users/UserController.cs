using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bearfood_API.Users;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserDbContext userDbContext;
    private readonly UserManager<User> userManager;
    
    public UserController(UserDbContext userDbContext, UserManager<User> userManager)
    {
        this.userDbContext = userDbContext;
        this.userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationDto userRegistrationDto)
    {
        if (!userRegistrationDto.IsValid)
        {
            return BadRequest();
        }

        var user = new User(userRegistrationDto.Username, userRegistrationDto.FullName);

        var result = await userManager.CreateAsync(user, userRegistrationDto.Password).ConfigureAwait(false);
        return !result.Succeeded ? Problem("Failed to insert new user!") : Ok();
    }

    [HttpGet("fullNames")]
    public IActionResult ListAllUsers()
    {
        return Ok(userDbContext.Users.Select(x => x.FullName).ToList());
    }
}