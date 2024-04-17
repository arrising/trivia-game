using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Mediators;

/// <summary>
///     Handles business logic regarding Round data
/// </summary>
public class RoundMediator : IRoundMediator
{
    private readonly IRepository<RoundEntity> _repository;

    public RoundMediator(IRepository<RoundEntity> repository)
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
