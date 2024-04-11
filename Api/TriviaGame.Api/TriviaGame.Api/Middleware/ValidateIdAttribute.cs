using Microsoft.AspNetCore.Mvc.Filters;

namespace TriviaGame.Api.Middleware;

[AttributeUsage(AttributeTargets.Method)]
public class ValidateIdAttribute : Attribute, IActionFilter
{
    public ValidateIdAttribute(string parameterName)
    {
        ParameterName = parameterName;
    }

    public string ParameterName { get; set; }

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
