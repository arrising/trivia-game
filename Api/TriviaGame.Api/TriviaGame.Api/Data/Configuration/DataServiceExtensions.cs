using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data.Configuration;

public static class DataServiceExtensions
{
    public static IServiceCollection AddApplicationDataServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var databaseConfig = configuration.GetSection(nameof(DatabaseConfiguration)).Get<DatabaseConfiguration>();
        databaseConfig.Validate();

        services
            .AddScoped<IRepository<CategoryEntity>, CategoryRepository>()
            .AddScoped<IRepository<GameEntity>, GameRepository>()
            .AddScoped<IRepository<RoundEntity>, RoundRepository>()
            .AddScoped<IRepository<QuestionEntity>, QuestionRepository>()
            .AddScoped<IComplexEntityRepository<GameEntity>, GameCreateRepository>();

        return databaseConfig.DatabaseType switch
        {
            DatabaseType.SqlLiteDb => services.UseSqlLiteDb(databaseConfig),
            DatabaseType.InMemoryDb => services.UseInMemoryDatabase(databaseConfig),
            _ => services.UseInMemoryDatabase(databaseConfig)
        };
    }

    public static void SetupDatabaseSeedData(this WebApplication app, IConfiguration configuration)
    {
        var databaseConfig = configuration.GetSection(nameof(DatabaseConfiguration)).Get<DatabaseConfiguration>();

        switch (databaseConfig.DatabaseType)
        {
            case DatabaseType.SqlLiteDb:
                app.SetupSqlLiteSeedData(databaseConfig);
                break;
            case DatabaseType.InMemoryDb:
            default:
                app.SetupInMemorySeedData(databaseConfig);
                break;
        }
    }
}
