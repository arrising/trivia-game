using Microsoft.AspNetCore.Mvc;

namespace TriviaGame.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/health")]
public class Health : Controller
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetHealth() => Ok();
}
