using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bearfood_API.Users;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserDbContext userDbContext;
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    
    public UserController(UserDbContext userDbContext, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        this.userDbContext = userDbContext;
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationDto registrationDto)
    {
        if (!registrationDto.IsValid)
        {
            return BadRequest();
        }

        var user = new User(registrationDto.Username, registrationDto.FullName);

        var result = await userManager.CreateAsync(user, registrationDto.Password).ConfigureAwait(false);
        return !result.Succeeded ? Problem("Failed to insert new user!") : Ok();
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        if (!login.IsValid)
        {
            return BadRequest();
        }

        var result = await signInManager.PasswordSignInAsync(login.Username, login.Password, isPersistent: true, lockoutOnFailure: false);
        
        return !result.Succeeded ? Unauthorized() : Ok();
    }

    [HttpGet("fullNames")]
    public IActionResult ListAllUsers()
    {
        return Ok(userDbContext.Users.Select(x => x.FullName).ToList());
    }
}