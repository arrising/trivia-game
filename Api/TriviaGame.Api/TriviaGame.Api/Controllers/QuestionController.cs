using Microsoft.AspNetCore.Mvc;
using TriviaGame.Api.Middleware;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/questions")]
public class QuestionController : Controller
{
    private readonly IQuestionProvider _provider;

    public QuestionController(IQuestionProvider provider)
    {
        _provider = provider;
    }


    [HttpGet("{questionId}", Name = "getQuestionById")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(QuestionDto))]
    [ValidateId("questionId")]
    public IActionResult GetById(string questionId)
    {
        var question = _provider.GetById(questionId);
        var result = new QuestionDto(question);
        return Ok(result);
    }

    [HttpGet("byCategoryId/{categoryId}", Name = "getQuestionsByCategoryId")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(QuestionDto[]))]
    [ValidateId("categoryId")]
    public IActionResult GetByRoundId(string categoryId)
    {
        var questions = _provider.GetByCategoryId(categoryId);
        var results = questions?.Select(x => new QuestionDto(x)) ?? Enumerable.Empty<QuestionDto>();
        return Ok(results);
    }
}
