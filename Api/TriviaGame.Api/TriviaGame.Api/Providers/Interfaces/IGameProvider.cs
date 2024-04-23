using TriviaGame.Api.Models.Dtos;

namespace TriviaGame.Api.Providers.Interfaces;

public interface IGameProvider
{
    GameDto GetById(string gameId);
    IEnumerable<GameDto> GetGames();
}
