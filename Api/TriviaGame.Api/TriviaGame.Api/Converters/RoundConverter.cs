using TriviaGame.Api.Converters.Interfaces;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Converters;

public class RoundConverter : IConverter<RoundEntity, RoundDto>
{
    public RoundDto Covert(RoundEntity value) => value != null
        ? new RoundDto
        {
            Id = value.Id,
            Type = value.Type,
            CategoryIds = value.Categories?.Any() == true
                ? value.Categories.Select(x => x.Id)
                : Enumerable.Empty<string>()
        }
        : null;
}
