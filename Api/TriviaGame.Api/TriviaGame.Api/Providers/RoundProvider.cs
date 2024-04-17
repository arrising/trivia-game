using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.Providers;

/// <summary>
///     Handles business logic regarding Round data
/// </summary>
public class RoundProvider : IRoundProvider
{
    private readonly IRepository<RoundEntity> _repository;

    public RoundProvider(IRepository<RoundEntity> repository)
    {
        _repository = repository;
    }

    public RoundEntity GetById(string roundId) =>
        _repository.GetById(roundId)
        ?? throw new NotFoundException($"RoundId '{roundId}' was not found");

    public IEnumerable<RoundEntity> GetByGameId(string gameId)
    {
        var result = _repository.GetByParentId(gameId);

        return result?.Any() == true
            ? result
            : throw new NotFoundException($"Rounds for {nameof(gameId)} '{gameId}' were not found");
    }
}
