using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models;
using TriviaGame.Api.Services.Interfaces;
using TriviaGame.Api.Validators.Interfaces;

namespace TriviaGame.Api.Services;

public class GameService : IGameService
{
    private readonly IRepository<Game> _repository;
    private readonly IIdValidator _validator;

    public GameService(IRepository<Game> repository, IIdValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public Game GetById(string gameId)
    {
        if (_validator.TryGetValidationException(gameId, nameof(gameId), out var exception))
        {
            throw exception;
        }

        return _repository.GetById(gameId) 
               ?? throw new NotFoundException($"GameId '{gameId}' was not found");
    }

    public IEnumerable<Game> GetGames() => _repository.GetAll();
}
