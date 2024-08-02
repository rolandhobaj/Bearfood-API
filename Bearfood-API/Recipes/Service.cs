namespace Bearfood_API.Recipes;

public class Service
{
    public IEnumerable<Recipe> GetAllRecipe()
    {
        return new[] {new Recipe(Guid.NewGuid(), "imageUri", "tags", "title")};
    }
}