using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Models.Dtos;

public class RoundDto
{
    public RoundDto() { }

    public RoundDto(RoundEntity round)
    {
        Id = round.Id;
        Type = round.Type;
        CategoryIds = round.Categories.Select(x => x.Id);
    }

    public string Id { get; set; }
    public string Type { get; set; }
    public IEnumerable<string> CategoryIds { get; set; } = new List<string>();
}
