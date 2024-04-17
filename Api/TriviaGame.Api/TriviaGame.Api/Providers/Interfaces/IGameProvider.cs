using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Providers.Interfaces;

public interface IGameProvider
{
    GameEntity GetById(string gameId);
    IEnumerable<GameEntity> GetGames();
}
