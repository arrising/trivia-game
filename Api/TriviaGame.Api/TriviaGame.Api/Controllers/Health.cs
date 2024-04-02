using Microsoft.AspNetCore.Mvc;

namespace TriviaGame.Api.Controllers;

[ApiController]
[Route("api/health")]
public class Health : Controller
{
    [HttpGet]
    public IActionResult GetHealth() => Ok();
}
