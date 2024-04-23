using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.Providers;

/// <summary>
///     Handles business logic regarding Game data
/// </summary>
public class GameProvider : IGameProvider
{
    private readonly IRepository<GameEntity> _repository;

    public GameProvider(IRepository<GameEntity> repository)
    {
        _repository = repository;
    }

    public GameDto GetById(string gameId)
    {
        var id = Guid.Parse(gameId);
        var entity = _repository.GetById(id);
        return entity != null ? new GameDto(entity) : throw new NotFoundException($"GameId '{gameId}' was not found");
    }

    public IEnumerable<GameDto> GetGames()
    {
        var entities = _repository.GetAll();

        return entities?.Any() == true
            ? entities.Select(entity => new GameDto(entity))
            : throw new NotFoundException("No Games  were not found");
    }
}
