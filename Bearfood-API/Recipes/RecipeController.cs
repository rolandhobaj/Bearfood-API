using Microsoft.AspNetCore.Mvc;

namespace Bearfood_API.Recipes;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var recipe = new { Id = 1, Name = "Leves" };
        return Ok(recipe);
    }
}