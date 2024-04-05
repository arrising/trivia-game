using Microsoft.AspNetCore.Mvc;
using TriviaGame.Api.Mediators.Interfaces;

namespace TriviaGame.Api.Controllers;

[ApiController]
[Route("api/rounds")]
public class RoundController : Controller
{
    private readonly IRoundMediator _mediator;

    public RoundController(IRoundMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{roundId}", Name = "getRoundById")]
    public IActionResult GetById(string roundId)
    {
        var round = _mediator.GetById(roundId);
        return Ok(round);
    }

    [HttpGet("byGameId/{gameId}", Name = "getRoundsByGameId")]
    public IActionResult GetByGameId(string gameId)
    {
        var rounds = _mediator.GetByGameId(gameId);
        return Ok(rounds);
    }
}
