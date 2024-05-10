using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Factories.Interfaces;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Models.Requests;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.Providers;

/// <summary>
///     Handles business logic regarding Game data
/// </summary>
public class GameProvider : IGameProvider
{
    private readonly IComplexEntityRepository<GameEntity> _complexRepository;
    private readonly IFactory<CreateGameRequest, GameEntity> _factory;
    private readonly IRepository<GameEntity> _repository;

    public GameProvider(
        IFactory<CreateGameRequest, GameEntity> factory,
        IRepository<GameEntity> repository,
        IComplexEntityRepository<GameEntity> complexRepository)
    {
        _repository = repository;
        _complexRepository = complexRepository;
        _factory = factory;
    }

    public async Task<GameDto> Create(CreateGameRequest request, CancellationToken token)
    {
        //TODO: Should Provider or repository be responsible for creating IDs
        var entity = _factory.Create(request);
        var saved = await _complexRepository.Add(entity, token);
        return new GameDto(saved);
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
