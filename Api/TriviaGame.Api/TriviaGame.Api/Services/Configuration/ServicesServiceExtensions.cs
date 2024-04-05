using System.Diagnostics.CodeAnalysis;
using TriviaGame.Api.Services.Interfaces;

namespace TriviaGame.Api.Services.Configuration;

[ExcludeFromCodeCoverage]
public static class ServicesServiceExtensions
{
    public static IServiceCollection UseApplicationServices(this IServiceCollection services) =>
        services
            .AddScoped<IGameService, GameService>()
            .AddScoped<IRoundService, RoundService>();
}
