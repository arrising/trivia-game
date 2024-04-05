using TriviaGame.Api.Validators.Interfaces;

namespace TriviaGame.Api.Validators.Configuration;

public static class ValidatorServiceExtensions
{
    public static IServiceCollection UseApplicationValidators(this IServiceCollection services) =>
        services
            .AddScoped<IIdValidator, IdValidator>();
}
