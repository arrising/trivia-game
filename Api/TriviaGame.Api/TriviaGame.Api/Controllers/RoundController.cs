using Microsoft.AspNetCore.Mvc;
using TriviaGame.Api.Services.Interfaces;

namespace TriviaGame.Api.Controllers;

[ApiController]
[Route("api/rounds")]
public class RoundController : Controller
{
    private readonly IRoundService _roundService;

    public RoundController(IRoundService roundService)
    {
        _roundService = roundService;
    }

    [HttpGet("{roundId}", Name = "getRoundById")]
    public IActionResult GetById(string roundId)
    {
        var game = _roundService.GetById(roundId);
        return Ok(game);
    }

    [HttpGet("byGameId/{gameId}", Name = "getRoundByGameId")]
    public IActionResult GetByGameId(string gameId)
    {
        var game = _roundService.GetByGameId(gameId);
        return Ok(game);
    }
}
