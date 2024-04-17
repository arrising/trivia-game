using Microsoft.AspNetCore.Mvc;
using TriviaGame.Api.Middleware;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.Controllers;

[ApiController]
[Route("api/games")]
[Produces("application/json")]
public class GameController : Controller
{
    private readonly IGameProvider _provider;

    public GameController(IGameProvider provider)
    {
        _provider = provider;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameDto[]))]
    public IActionResult GetAllGames()
    {
        var games = _provider.GetGames();
        var result = games?.Select(x => new GameDto(x)) ?? Enumerable.Empty<GameDto>();
        return Ok(result);
    }

    [HttpGet("{gameId}", Name = "getGameById")]
    [ValidateId("gameId")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameDto))]
    public IActionResult GetById(string gameId)
    {
        var game = _provider.GetById(gameId);
        var result = new GameDto(game);
        return Ok(result);
    }
}
