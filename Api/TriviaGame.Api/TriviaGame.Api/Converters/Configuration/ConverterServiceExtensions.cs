using TriviaGame.Api.Converters.Interfaces;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Converters.Configuration;

public static class ConverterServiceExtensions
{
    public static IServiceCollection AddApplicationConverters(this IServiceCollection services) =>
        services
            .AddScoped<IConverter<CategoryEntity, CategoryDto>, CategoryConverter>()
            .AddScoped<IConverter<GameEntity, GameDto>, GameConverter>()
            .AddScoped<IConverter<QuestionEntity, QuestionDto>, QuestionConverter>()
            .AddScoped<IConverter<QuestionEntity, QuestionPointerDto>, QuestionPointerConverter>()
            .AddScoped<IConverter<RoundEntity, RoundDto>, RoundConverter>();
}
