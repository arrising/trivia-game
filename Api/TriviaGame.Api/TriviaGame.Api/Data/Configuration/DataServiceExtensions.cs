using TriviaGame.Api.Data.InMemoryDb;
using TriviaGame.Api.Data.InMemoryDb.Configuration;
using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data.Configuration;

public static class DataServiceExtensions
{
    public static IServiceCollection AddApplicationDataServices(this IServiceCollection services, IConfiguration configuration)
    {

        var databaseConfig = configuration.GetSection(nameof(DatabaseConfiguration)).Get<DatabaseConfiguration>();
        databaseConfig.Validate();

        services
            .UseEntityFrameworkRepositories()
            .UseInMemoryDatabase(databaseConfig);

        return services;
    }

    private static IServiceCollection UseEntityFrameworkRepositories(this IServiceCollection services) =>
        services
            .AddScoped<IRepository<CategoryEntity>, CategoryRepository>()
            .AddScoped<IRepository<GameEntity>, GameRepository>()
            .AddScoped<IRepository<RoundEntity>, RoundRepository>()
            .AddScoped<IRepository<QuestionEntity>, QuestionRepository>();
}
