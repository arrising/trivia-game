using Microsoft.AspNetCore.Mvc;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Middleware;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/rounds")]
public class RoundController : Controller
{
    private readonly IRoundMediator _mediator;

    public RoundController(IRoundMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{roundId}", Name = "getRoundById")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoundDto))]
    [ValidateId("roundId")]
    public IActionResult GetById(string roundId)
    {
        var round = _mediator.GetById(roundId);
        var result = new RoundDto(round);
        return Ok(result);
    }

    [HttpGet("byGameId/{gameId}", Name = "getRoundsByGameId")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoundDto[]))]

    [ValidateId("gameId")]
    public IActionResult GetByGameId(string gameId)
    {
        var rounds = _mediator.GetByGameId(gameId);
        var result = rounds?.Select(x => new RoundDto(x)) ?? Enumerable.Empty<RoundDto>();
        return Ok(result);
    }
}
