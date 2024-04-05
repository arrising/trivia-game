using Microsoft.AspNetCore.Mvc;
using TriviaGame.Api.Mediators.Interfaces;

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
        return Ok(category);
    }

    [HttpGet("byRoundId/{roundId}", Name = "getCategoriesByRoundId")]
    public IActionResult GetByRoundId(string roundId)
    {
        var categories = _mediator.GetByRoundId(roundId);
        return Ok(categories);
    }
}
