namespace TriviaGame.Api.Models;

public class RoundDto
{
    public RoundDto() { }

    public RoundDto(Round round)
    {
        Id = round.Id;
        Type = round.Type;
        CategoryIds = round.Categories.Select(x => x.Id);
    }

    public string Id { get; set; }
    public string Type { get; set; }
    public IEnumerable<string> CategoryIds { get; set; }
}
