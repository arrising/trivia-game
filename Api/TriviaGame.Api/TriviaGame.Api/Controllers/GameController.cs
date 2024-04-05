using Microsoft.AspNetCore.Mvc;
using TriviaGame.Api.Mediators.Interfaces;

namespace TriviaGame.Api.Controllers;

[ApiController]
[Route("api/games")]
public class GameController : Controller
{
    private readonly IGameMediator _mediator;

    public GameController(IGameMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult GetAllGames()
    {
        var games = _mediator.GetGames();
        return Ok(games);
    }

    [HttpGet("{gameId}", Name = "getGameById")]
    public IActionResult GetById(string gameId)
    {
        var game = _mediator.GetById(gameId);
        return Ok(game);
    }
}
