using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Providers.Interfaces;

public interface IRoundProvider
{
    RoundEntity GetById(string roundId);
    IEnumerable<RoundEntity> GetByGameId(string gameId);
}
