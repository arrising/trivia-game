using Microsoft.AspNetCore.Mvc;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.Controllers;

[ApiController]
[Route("api/questions")]
public class QuestionController : Controller
{
    private readonly IQuestionMediator _mediator;

    public QuestionController(IQuestionMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("{questionId}", Name = "getQuestionById")]
    public IActionResult GetById(string questionId)
    {
        var question = _mediator.GetById(questionId);
        var result = new QuestionDto(question);
        return Ok(result);
    }

    [HttpGet("byCategoryId/{categoryId}", Name = "getQuestionsByCategoryId")]
    public IActionResult GetByRoundId(string categoryId)
    {
        var questions = _mediator.GetByCategoryId(categoryId);
        var results = questions?.Select(x => new QuestionDto(x)) ?? Enumerable.Empty<QuestionDto>();
        return Ok(results);
    }
}
