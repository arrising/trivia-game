using TriviaGame.Api.Converters.Interfaces;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Converters;

public class GameConverter : IConverter<GameEntity, GameDto>
{
    public GameDto Covert(GameEntity value) => value != null
        ? new GameDto
        {
            Id = value.Id,
            Name = value.Name,
            ValueSymbol = value.ValueSymbol,
            RoundIds = value.Rounds?.Any() == true ? value.Rounds.Select(x => x.Id) : Enumerable.Empty<string>()
        }
        : null;
}
