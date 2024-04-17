using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Mediators;

/// <summary>
///     Handles business logic regarding Game data
/// </summary>
public class GameMediator : IGameMediator
{
    private readonly IRepository<GameEntity> _repository;

    public GameMediator(IRepository<GameEntity> repository)
    {
        _repository = repository;
    }

    public GameEntity GetById(string gameId) =>
        _repository.GetById(gameId)
        ?? throw new NotFoundException($"GameId '{gameId}' was not found");

    public IEnumerable<GameEntity> GetGames() => _repository.GetAll();
}
