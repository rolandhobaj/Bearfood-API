using System.Collections.Immutable;
using Google.Cloud.Firestore;
using Optional;
using Optional.Collections;

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
        var recipes = ConvertToRecipes(querySnapshot);

        return recipes;
    }

    public async Task<Option<Recipe>> GetRecipe(string id)
    {
        var querySnapshot = await firestoreService.GetRecipe(id);
        var recipes = ConvertToRecipes(querySnapshot);

        return recipes.FirstOrNone();
    }


    private static ImmutableArray<Recipe> ConvertToRecipes(QuerySnapshot querySnapshot)
    {
        var recipes = querySnapshot.Documents
            .Where(x => x.Exists)
            .Select(d => d.ConvertTo<Recipe>())
            .ToImmutableArray();
        return recipes;
    }
}