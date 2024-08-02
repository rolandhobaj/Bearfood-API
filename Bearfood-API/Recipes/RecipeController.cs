using Microsoft.AspNetCore.Mvc;

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
    public IActionResult Get()
    {
        return Ok(service.GetAllRecipe());
    }
}