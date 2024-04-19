using Microsoft.EntityFrameworkCore;
using TriviaGame.Api.Data.Interfaces;

namespace TriviaGame.Api.Data.Configuration;

public static class SqlLIteDbServiceExtensions
{
    public static IServiceCollection UseSqlLiteDb(this IServiceCollection services,
        DatabaseConfiguration configuration)
    {

        services
            .AddDbContext<TriviaGameDbContext>(options => { options.UseSqlite($"Data Source={configuration.SqlLiteDbPath}"); });

        return services
            .AddScoped<IDbContext>(provider => provider.GetRequiredService<TriviaGameDbContext>());
    }

    public static void SetupSqlLiteSeedData(this WebApplication app, DatabaseConfiguration configuration)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TriviaGameDbContext>();

        // Assure database always uses latest schema
        dbContext.Database.Migrate();
        new DbSeeder(dbContext, configuration).Seed().Wait();
    }
}
