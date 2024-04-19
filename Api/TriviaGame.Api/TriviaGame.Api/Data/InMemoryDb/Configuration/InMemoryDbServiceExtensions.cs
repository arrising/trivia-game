﻿using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TriviaGame.Api.Data.Configuration;
using TriviaGame.Api.Data.Interfaces;

namespace TriviaGame.Api.Data.InMemoryDb.Configuration;

[ExcludeFromCodeCoverage]
public static class InMemoryDbServiceExtensions
{
    public static IServiceCollection UseInMemoryDatabase(this IServiceCollection services,
        DatabaseConfiguration configuration)
    {
        services
            .AddDbContext<TriviaGameDbContext>(options => { options.UseInMemoryDatabase(configuration.DatabaseName); });

        return services
            .AddScoped<IDbContext>(provider => provider.GetRequiredService<TriviaGameDbContext>());
    }

    public static void SetupInMemorySeedData(this WebApplication app, DatabaseConfiguration configuration)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TriviaGameDbContext>();
        new InMemoryDbSeeder(dbContext, configuration).Seed().Wait();
    }
}
