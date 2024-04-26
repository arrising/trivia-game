using TriviaGame.Api.Factories.Interfaces;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Models.Requests;

namespace TriviaGame.Api.Factories.Configuration
{
    public static class FactoryServiceExtensions
    {
        public static IServiceCollection AddApplicationFactories(this IServiceCollection services) => 
            services
                .AddScoped<IFactory<CreateGameRequest, GameEntity>, GameFactory>()
                .AddScoped<IFactory<CreateRoundRequest, RoundEntity>, RoundFactory>()
                .AddScoped<IFactory<CreateCategoryRequest, CategoryEntity>, CategoryFactory>()
                .AddScoped<IFactory<CreateQuestionRequest, QuestionEntity>, QuestionFactory>();
    }
}
