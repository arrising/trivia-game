using Microsoft.AspNetCore.Mvc;
using TriviaGame.Api.Middleware;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/categories")]
public class CategoryController : Controller
{
    private readonly ICategoryProvider _provider;

    public CategoryController(ICategoryProvider provider)
    {
        _provider = provider;
    }

    [HttpGet("{categoryId}", Name = "getCategoryById")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDto))]
    [ValidateId("categoryId")]
    public IActionResult GetById(string categoryId)
    {
        var result = _provider.GetById(categoryId);
        return Ok(result);
    }

    [HttpGet("byRoundId/{roundId}", Name = "getCategoriesByRoundId")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDto[]))]
    [ValidateId("roundId")]
    public IActionResult GetByRoundId(string roundId)
    {
        var results = _provider.GetByRoundId(roundId);
        return Ok(results);
    }
}
