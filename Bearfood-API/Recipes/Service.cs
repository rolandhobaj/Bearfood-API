using System.Collections.Immutable;

namespace Bearfood_API.Recipes;

public class Service : IService
{
    private readonly Firestore.Service firestoreService;

    public Service(Firestore.Service firestoreService)
    {
        this.firestoreService = firestoreService;
    }

    public async Task<IEnumerable<Recipe>> GetAllRecipe()
    {
        var querySnapshot = await firestoreService.GetAllRecipes();
        var recipes = querySnapshot.Documents
            .Where(x => x.Exists)
            .Select(d => d.ConvertTo<Recipe>())
            .ToImmutableArray();

        return recipes;
    }
}