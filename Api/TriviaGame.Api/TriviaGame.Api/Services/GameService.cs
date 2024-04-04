using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models;
using TriviaGame.Api.Services.Interfaces;

namespace TriviaGame.Api.Services;

public class GameService : IGameService
{
    private readonly IRepository<Game> _repository;

    public GameService(IRepository<Game> repository)
    {
        _repository = repository;
    }

    public Game GetById(string gameId)
    {
        if (string.IsNullOrWhiteSpace(gameId))
        {
            throw new ArgumentException("game id must have a value", nameof(gameId));
        }

        return _repository.GetById(gameId) 
               ?? throw new NotFoundException($"GameId '{gameId}' was not found");
    }

    public IEnumerable<Game> GetGames() => _repository.GetAll();
}
