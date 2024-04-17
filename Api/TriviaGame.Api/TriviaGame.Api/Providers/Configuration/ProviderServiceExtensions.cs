using System.Diagnostics.CodeAnalysis;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.Providers.Configuration;

[ExcludeFromCodeCoverage]
public static class ProviderServiceExtensions
{
    public static IServiceCollection UseApplicationProviders(this IServiceCollection services) =>
        services
            .AddScoped<ICategoryProvider, CategoryProvider>()
            .AddScoped<IGameProvider, GameProvider>()
            .AddScoped<IQuestionProvider, QuestionProvider>()
            .AddScoped<IRoundProvider, RoundProvider>();
}
