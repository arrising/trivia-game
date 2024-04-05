using TriviaGame.Api.Models;

namespace TriviaGame.Api.Mediators.Interfaces;

public interface IGameMediator
{
    Game GetById(string gameId);
    IEnumerable<Game> GetGames();
}
