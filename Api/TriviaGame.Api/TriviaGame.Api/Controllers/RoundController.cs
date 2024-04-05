using Microsoft.AspNetCore.Mvc;
using TriviaGame.Api.Mediators.Interfaces;

namespace TriviaGame.Api.Controllers;

[ApiController]
[Route("api/rounds")]
public class RoundController : Controller
{
    private readonly IRoundMediator _roundMediator;

    public RoundController(IRoundMediator roundMediator)
    {
        _roundMediator = roundMediator;
    }

    [HttpGet("{roundId}", Name = "getRoundById")]
    public IActionResult GetById(string roundId)
    {
        var game = _roundMediator.GetById(roundId);
        return Ok(game);
    }

    [HttpGet("byGameId/{gameId}", Name = "getRoundByGameId")]
    public IActionResult GetByGameId(string gameId)
    {
        var game = _roundMediator.GetByGameId(gameId);
        return Ok(game);
    }
}
