using System.Diagnostics.CodeAnalysis;
using TriviaGame.Api.Mediators.Interfaces;

namespace TriviaGame.Api.Mediators.Configuration;

[ExcludeFromCodeCoverage]
public static class MediatorsServiceExtensions
{
    public static IServiceCollection UseApplicationServices(this IServiceCollection services) =>
        services
            .AddScoped<IGameMediator, GameMediator>()
            .AddScoped<IRoundMediator, RoundMediator>();
}
