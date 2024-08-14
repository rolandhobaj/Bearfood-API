using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bearfood_API.Users;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserDbContext userDbContext;
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly TokenService tokenService;

    public UserController(UserDbContext userDbContext, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
    {
        this.userDbContext = userDbContext;
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.tokenService = tokenService;
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

        var user = await userManager.Users.FirstOrDefaultAsync(x => x.UserName == login.Username.ToLower());

        if (user == null)
        {
            return Unauthorized("Invalid username!");
        }
        
        var result = await signInManager.PasswordSignInAsync(login.Username, login.Password, isPersistent: true, lockoutOnFailure: false);
        
        return !result.Succeeded ? Unauthorized() : Ok(new
        {
            UserName = user.UserName,
            FullName = user.FullName,
            Token = tokenService.CreateToken(user)
        });
    }

    [HttpGet("fullNames")]
    public IActionResult ListAllUsers()
    {
        return Ok(userDbContext.Users.Select(x => x.FullName).ToList());
    }
}