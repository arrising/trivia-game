using Microsoft.AspNetCore.Mvc.Filters;
using TriviaGame.Api.Validators.Interfaces;

namespace TriviaGame.Api.Middleware;

public class ValidateIdActionFilter : IActionFilter
{
    private readonly IIdValidator _validator;

    public ValidateIdActionFilter(IIdValidator validator)
    {
        _validator = validator;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var attribute = context.ActionDescriptor.EndpointMetadata.OfType<ValidateIdAttribute>()
            .FirstOrDefault(x => !string.IsNullOrWhiteSpace(x.ParameterName));
        if (attribute != null)
        {
            if (context.ActionArguments.TryGetValue(attribute.ParameterName, out var value))
            {
                if (_validator.TryGetValidationException(value?.ToString(), attribute.ParameterName, out var exception))
                {
                    throw exception;
                }
            }
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
