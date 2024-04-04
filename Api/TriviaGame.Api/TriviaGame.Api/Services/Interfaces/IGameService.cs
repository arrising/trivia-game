using TriviaGame.Api.Models;

namespace TriviaGame.Api.Services.Interfaces;

public interface IGameService
{
    Game GetById(string gameId);
    IEnumerable<Game> GetGames();
}
