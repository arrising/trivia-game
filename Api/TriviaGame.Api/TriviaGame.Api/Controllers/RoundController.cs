using Microsoft.AspNetCore.Mvc;
using TriviaGame.Api.Middleware;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/rounds")]
public class RoundController : Controller
{
    private readonly IRoundProvider _provider;

    public RoundController(IRoundProvider provider)
    {
        _provider = provider;
    }

    [HttpGet("{roundId}", Name = "getRoundById")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoundDto))]
    [ValidateId("roundId")]
    public IActionResult GetById(string roundId)
    {
        var result = _provider.GetById(roundId);
        return Ok(result);
    }

    [HttpGet("byGameId/{gameId}", Name = "getRoundsByGameId")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoundDto[]))]
    [ValidateId("gameId")]
    public IActionResult GetByGameId(string gameId)
    {
        var results = _provider.GetByGameId(gameId);
        return Ok(results);
    }
}
