using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.Mediators;

/// <summary>
///     Handles business logic regarding Game data
/// </summary>
public class GameMediator : IGameMediator
{
    private readonly IRepository<Game> _repository;

    public GameMediator(IRepository<Game> repository)
    {
        _repository = repository;
    }

    public Game GetById(string gameId) =>
        _repository.GetById(gameId)
        ?? throw new NotFoundException($"GameId '{gameId}' was not found");

    public IEnumerable<Game> GetGames() => _repository.GetAll();
}
