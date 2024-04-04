namespace TriviaGame.Api.Middleware.Configuration;

public static class MiddlewareServiceExtensions
{
    public static WebApplication UseApplicationMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();

        return app;
    }
}
