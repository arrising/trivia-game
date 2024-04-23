using TriviaGame.Api.Models.Dtos;

namespace TriviaGame.Api.Providers.Interfaces;

public interface IRoundProvider
{
    RoundDto GetById(string roundId);
    IEnumerable<RoundDto> GetByGameId(string gameId);
}
