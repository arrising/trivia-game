using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data.InMemoryDb.Configuration;

[ExcludeFromCodeCoverage]
public static class InMemoryDbServiceExtensions
{
    public static IServiceCollection UseInMemoryDatabase(this IServiceCollection services)
    {
        services
            .AddScoped<IRepository<CategoryEntity>, CategoryRepository>()
            .AddScoped<IRepository<GameEntity>, GameRepository>()
            .AddScoped<IRepository<RoundEntity>, RoundRepository>()
            .AddScoped<IRepository<QuestionEntity>, QuestionRepository>()
            .AddDbContext<TriviaGameDbContext>(options => { options.UseInMemoryDatabase(InMemoryDbConstants.DbName); });

        SeedInMemoryDb().Wait();

        return services;
    }

    public static Task SeedInMemoryDb() =>
        new InMemoryDbSeeder(
            new TriviaGameDbContext(
                new DbContextOptionsBuilder<TriviaGameDbContext>()
                    .UseInMemoryDatabase(InMemoryDbConstants.DbName).Options
            )).Seed();
}
