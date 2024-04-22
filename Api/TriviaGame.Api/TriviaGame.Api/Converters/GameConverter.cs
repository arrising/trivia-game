using TriviaGame.Api.Converters.Interfaces;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Converters;

public class GameConverter : IConverter<GameEntity, GameDto>
{
    public GameDto Covert(GameEntity value) => value != null ? new GameDto(value) : null;
}
