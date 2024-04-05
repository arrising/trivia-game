using TriviaGame.Api.Models;

namespace TriviaGame.Api.Mediators.Interfaces;

public interface IRoundMediator
{
    Round GetById(string roundId);
    IEnumerable<Round> GetByGameId(string gameId);
}
