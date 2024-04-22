using TriviaGame.Api.Converters.Interfaces;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Converters;

public class RoundConverter : IConverter<RoundEntity, RoundDto>
{
    public RoundDto Covert(RoundEntity value) => value != null ? new RoundDto(value) : null;
}
