namespace Bearfood_API.Recipes;

public record Recipe
{
    public Recipe(Guid id, string imageUri, string tags, string title)
    {
        Id = id;
        ImageUri = imageUri;
        Tags = tags;
        Title = title;
    }

    public Guid Id { get; init; }

    public string ImageUri { get; init; }

    public string Tags { get; init; }

    public string Title { get; init; }
}