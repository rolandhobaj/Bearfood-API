using Microsoft.AspNetCore.Mvc;
using Optional.Unsafe;

namespace Bearfood_API.Recipes;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
    private readonly Service service;

    public RecipeController(Service service)
    {
        this.service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllRecipes()
    {
        return Ok(await service.GetAllRecipe());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecipe(string id)
    {
        var recipe = await service.GetRecipe(id);
        if (recipe.HasValue)
        {
            return Ok(recipe.ValueOrDefault());
        }

        return NotFound();
    }
}