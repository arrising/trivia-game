using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
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

    public GameEntity GetById(string gameId) =>
        _repository.GetById(gameId)
        ?? throw new NotFoundException($"GameId '{gameId}' was not found");

    public IEnumerable<GameEntity> GetGames() => _repository.GetAll();
}
