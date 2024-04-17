using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Mediators.Interfaces;

public interface IRoundMediator
{
    RoundEntity GetById(string roundId);
    IEnumerable<RoundEntity> GetByGameId(string gameId);
}
