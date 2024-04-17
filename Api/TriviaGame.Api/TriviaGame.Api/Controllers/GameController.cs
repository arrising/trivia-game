using Microsoft.AspNetCore.Mvc;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Middleware;
using TriviaGame.Api.Models.Dtos;

namespace TriviaGame.Api.Controllers;

[ApiController]
[Route("api/games")]
[Produces("application/json")]
public class GameController : Controller
{
    private readonly IGameMediator _mediator;

    public GameController(IGameMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameDto[]))]
    public IActionResult GetAllGames()
    {
        var games = _mediator.GetGames();
        var result = games?.Select(x => new GameDto(x)) ?? Enumerable.Empty<GameDto>();
        return Ok(result);
    }

    [HttpGet("{gameId}", Name = "getGameById")]
    [ValidateId("gameId")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameDto))]
    public IActionResult GetById(string gameId)
    {
        var game = _mediator.GetById(gameId);
        var result = new GameDto(game);
        return Ok(result);
    }
}
