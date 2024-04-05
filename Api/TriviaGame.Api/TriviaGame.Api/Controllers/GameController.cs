using Microsoft.AspNetCore.Mvc;
using TriviaGame.Api.Mediators.Interfaces;

namespace TriviaGame.Api.Controllers;

[ApiController]
[Route("api/games")]
public class GameController : Controller
{
    private readonly IGameMediator _gameMediator;

    public GameController(IGameMediator gameMediator)
    {
        _gameMediator = gameMediator;
    }

    [HttpGet]
    public IActionResult GetAllGames()
    {
        var games = _gameMediator.GetGames();
        return Ok(games);
    }

    [HttpGet("{gameId}", Name = "getGameById")]
    public IActionResult GetById(string gameId)
    {
        var game = _gameMediator.GetById(gameId);
        return Ok(game);
    }
}
