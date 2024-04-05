namespace TriviaGame.Api.Models;

public class Category
{
    public string Id { get; set; }
    public string RoundId { get; set; }
    public string Name { get; set; }
    public string? Note { get; set; }
}
