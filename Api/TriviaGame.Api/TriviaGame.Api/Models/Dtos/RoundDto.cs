using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Models.Dtos;

public class RoundDto
{
    public RoundDto() { }

    public RoundDto(RoundEntity round)
    {
        if (round == null)
        {
            throw new ConversionNullException(nameof(round));
        }

        Id = round.Id;
        Type = round.Type;
        CategoryIds = round.Categories?.Select(x => x.Id) ?? Enumerable.Empty<string>();
    }

    public string Id { get; set; }
    public string Type { get; set; }
    public IEnumerable<string> CategoryIds { get; set; } = Enumerable.Empty<string>();
}
