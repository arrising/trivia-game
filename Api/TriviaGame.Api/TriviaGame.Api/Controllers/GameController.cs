using Microsoft.AspNetCore.Mvc;
using TriviaGame.Api.Services.Interfaces;

namespace TriviaGame.Api.Controllers;

[ApiController]
[Route("api/games")]
public class GameController : Controller
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet]
    public IActionResult GetAllGames()
    {
        var games = _gameService.GetGames();
        return Ok(games);
    }

    [HttpGet("{gameId}", Name = "getGameById")]
    public IActionResult GetById(string gameId)
    {
        var game = _gameService.GetById(gameId);
        return Ok(game);
    }
}
