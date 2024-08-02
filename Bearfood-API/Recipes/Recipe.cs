using Google.Cloud.Firestore;

namespace Bearfood_API.Recipes;

[FirestoreData]
public class Recipe
{
    [FirestoreProperty("id")] public string Id { get; set; } = string.Empty;

    [FirestoreProperty("imageUri")] public string ImageUri { get; set; } = string.Empty;

    [FirestoreProperty("tags")] public string Tags { get; set; } = string.Empty;

    [FirestoreProperty("title")] public string Title { get; set; } = string.Empty;
}