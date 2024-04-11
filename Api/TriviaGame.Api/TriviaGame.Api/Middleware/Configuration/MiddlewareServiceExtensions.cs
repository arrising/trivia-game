using Microsoft.AspNetCore.Mvc;

namespace TriviaGame.Api.Middleware.Configuration;

public static class MiddlewareServiceExtensions
{
    public static void UseApplicationActionFilters(this MvcOptions options)
    {
        options.Filters.Add<ValidateIdActionFilter>();
    }

    public static WebApplication UseApplicationMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();

        return app;
    }
}
