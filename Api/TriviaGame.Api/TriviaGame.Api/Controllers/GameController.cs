using Microsoft.AspNetCore.Mvc;
using TriviaGame.Api.Middleware;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Requests;
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameDto[]))]
    public async Task<IActionResult> CreateGame([FromBody] CreateGameRequest request, CancellationToken token)
    {
        var result = await _provider.Create(request, token);
        var uri = $"{HttpContext.Request.PathBase}/api/games/{result.Id}";
        return Created(uri, result);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameDto[]))]
    public IActionResult GetAllGames()
    {
        var result = _provider.GetGames();
        return Ok(result);
    }

    [HttpGet("{gameId}", Name = "getGameById")]
    [ValidateId("gameId")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameDto))]
    public IActionResult GetById(string gameId)
    {
        var results = _provider.GetById(gameId);
        return Ok(results);
    }

    [HttpPatch("{gameId}", Name = "updateGameById")]
    [ValidateId("gameId")]
    public async Task<IActionResult> Update([FromRoute] string gameId, [FromBody] UpdateGameRequest value)
    {
        var result = await _provider.Update(gameId, value);
        return Ok(result);
    }
}
