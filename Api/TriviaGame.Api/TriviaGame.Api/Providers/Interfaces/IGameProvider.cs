using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Requests;

namespace TriviaGame.Api.Providers.Interfaces;

public interface IGameProvider
{
    Task<GameDto> Create(CreateGameRequest request, CancellationToken token);
    GameDto GetById(string gameId);
    IEnumerable<GameDto> GetGames();
}
