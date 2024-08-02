using Google.Cloud.Firestore;

namespace Bearfood_API.Firestore;

public class Service : IService
{
    private readonly FirestoreDb db;

    public Service()
    {
        const string pathToCredentials = "Firestore/Credentials.json";

        var builder = new FirestoreDbBuilder
        {
            ProjectId = "bearfood-a9597",
            JsonCredentials = File.ReadAllText(pathToCredentials)
        };

        db = builder.Build();
    }
    
    public async Task<QuerySnapshot> GetAllRecipes()
    {
        var collection = db.Collection("recipesV2");
        return await collection.GetSnapshotAsync();
    }
    
    public async Task<QuerySnapshot> GetRecipe(string id)
    {
        var query = db.Collection("recipesV2").WhereEqualTo("id", id);
        return await query.GetSnapshotAsync();
    }
}