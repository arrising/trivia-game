using Microsoft.AspNetCore.Mvc;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Middleware;
using TriviaGame.Api.Models;

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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Game))]
    public IActionResult GetAllGames()
    {
        var games = _mediator.GetGames();
        return Ok(games);
    }

    [HttpGet("{gameId}", Name = "getGameById")]
    [ValidateId("gameId")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Game))]
    public IActionResult GetById(string gameId)
    {
        var game = _mediator.GetById(gameId);
        return Ok(game);
    }
}
