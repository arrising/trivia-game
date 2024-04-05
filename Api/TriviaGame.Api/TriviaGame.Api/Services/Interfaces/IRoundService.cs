using TriviaGame.Api.Models;

namespace TriviaGame.Api.Services.Interfaces;

public interface IRoundService
{
    Round GetById(string roundId);
    IEnumerable<Round> GetByGameId(string gameId);
}
