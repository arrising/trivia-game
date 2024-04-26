using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Dtos;
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

    public RoundDto GetById(string roundId)
    {
        var id = Guid.Parse(roundId);
        var entity = _repository.GetById(id);
        return entity != null
            ? new RoundDto(entity)
            : throw new NotFoundException($"RoundNumber '{roundId}' was not found");
    }

    public IEnumerable<RoundDto> GetByGameId(string gameId)
    {
        var id = Guid.Parse(gameId);
        var entities = _repository.GetByParentId(id);

        return entities?.Any() == true
            ? entities.Select(entity => new RoundDto(entity))
            : throw new NotFoundException($"Rounds for {nameof(gameId)} '{gameId}' were not found");
    }
}
