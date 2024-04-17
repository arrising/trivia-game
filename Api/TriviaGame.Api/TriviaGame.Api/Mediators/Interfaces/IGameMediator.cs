using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Mediators.Interfaces;

public interface IGameMediator
{
    GameEntity GetById(string gameId);
    IEnumerable<GameEntity> GetGames();
}
