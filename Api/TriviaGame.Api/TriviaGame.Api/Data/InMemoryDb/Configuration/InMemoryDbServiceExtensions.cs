using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TriviaGame.Api.Data.Configuration;

namespace TriviaGame.Api.Data.InMemoryDb.Configuration;

[ExcludeFromCodeCoverage]
public static class InMemoryDbServiceExtensions
{
    public static IServiceCollection UseInMemoryDatabase(this IServiceCollection services,
        DatabaseConfiguration configuration)
    {
        SeedInMemoryDb(configuration).Wait();

        services
            .AddDbContext<TriviaGameDbContext>(options => { options.UseInMemoryDatabase(configuration.DatabaseName); });

        return services;
    }

    public static Task SeedInMemoryDb(DatabaseConfiguration configuration) =>
        new InMemoryDbSeeder(
            new TriviaGameDbContext(
                new DbContextOptionsBuilder<TriviaGameDbContext>()
                    .UseInMemoryDatabase(configuration.DatabaseName).Options)
            , configuration).Seed();
}
