using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models;
using TriviaGame.Api.Services.Interfaces;
using TriviaGame.Api.Validators.Interfaces;

namespace TriviaGame.Api.Services;

public class RoundService : IRoundService
{
    private readonly IRepository<Round> _repository;
    private readonly IIdValidator _validator;

    public RoundService(IRepository<Round> repository, IIdValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public Round GetById(string roundId)
    {
        if (_validator.TryGetValidationException(roundId, nameof(roundId), out var exception))
        {
            throw exception;
        }

        return _repository.GetById(roundId)
               ?? throw new NotFoundException($"RoundId '{roundId}' was not found");
    }

    public IEnumerable<Round> GetByGameId(string gameId)
    {
        if (_validator.TryGetValidationException(gameId, nameof(gameId), out var exception))
        {
            throw exception;
        }

        var result = _repository.GetByParentId(gameId);

        return result?.Any() == true
            ? result
            : throw new NotFoundException($"Rounds for gameId '{gameId}' were not found");
    }
}
