using Microsoft.AspNetCore.Mvc;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController : Controller
{
    private readonly ICategoryMediator _mediator;

    public CategoryController(ICategoryMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{categoryId}", Name = "getCategoryById")]
    public IActionResult GetById(string categoryId)
    {
        var category = _mediator.GetById(categoryId);
        var result = new CategoryDto(category);
        return Ok(result);
    }

    [HttpGet("byRoundId/{roundId}", Name = "getCategoriesByRoundId")]
    public IActionResult GetByRoundId(string roundId)
    {
        var categories = _mediator.GetByRoundId(roundId);
        var results = categories?.Select(x => new CategoryDto(x)) ?? Enumerable.Empty<CategoryDto>();
        return Ok(results);
    }
}
