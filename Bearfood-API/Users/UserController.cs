using Microsoft.AspNetCore.Mvc;

namespace Bearfood_API.Users;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserDbContext userDbContext;

    public UserController(UserDbContext userDbContext)
    {
        this.userDbContext = userDbContext;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationDto userRegistrationDto)
    {
        if (!userRegistrationDto.IsValid)
        {
            return BadRequest();
        }

        var user = new User()
        {
            UserName = userRegistrationDto.Username,
            PasswordHash = userRegistrationDto.Password,
            FullName = userRegistrationDto.FullName ?? string.Empty,
        };

        await userDbContext.AddAsync(user).ConfigureAwait(false);
        var result = await userDbContext.SaveChangesAsync();
        return result != 1 ? Problem("Failed to insert new user!") : Ok();
    }

    [HttpGet("fullNames")]
    public IActionResult ListAllUsers()
    {
        return Ok(userDbContext.Users.Select(x => x.FullName).ToList());
    }
}