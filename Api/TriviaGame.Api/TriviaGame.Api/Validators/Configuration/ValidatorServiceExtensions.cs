using TriviaGame.Api.Validators.Interfaces;

namespace TriviaGame.Api.Validators.Configuration;

public static class ValidatorServiceExtensions
{
    public static IServiceCollection AddApplicationValidators(this IServiceCollection services) =>
        services
            .AddScoped<IIdValidator, IdValidator>();
}
