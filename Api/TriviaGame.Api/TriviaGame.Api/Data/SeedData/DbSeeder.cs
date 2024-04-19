using System.Text.Json;
using TriviaGame.Api.Data.Configuration;
using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data.SeedData;

public class DbSeeder : IDbSeeder
{
    private readonly DatabaseConfiguration _configuration;
    private readonly IDbContext _context;

    public DbSeeder(IDbContext context, DatabaseConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task Seed()
    {
        // Only process if DB is empty
        if (!_context.Games.Any())
        {
            var data = BuildGameSeedData();

            _context.Games.AddRange(data.Games);
            _context.Rounds.AddRange(data.Rounds);
            _context.Categories.AddRange(data.Categories);
            _context.Questions.AddRange(data.Questions);

            await _context.SaveChangesAsync();
        }
        else
        {
            // Assures a task is always completed.
            await Task.CompletedTask;
        }
    }

    public SeedData BuildGameSeedData()
    {
        using var fileStream = new FileStream(_configuration.SeedFilePath, FileMode.Open);
        using var streamReader = new StreamReader(fileStream);
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var games = JsonSerializer.Deserialize<List<GameEntity>>(fileStream, options) ?? new List<GameEntity>();

        var seedData = ExtractSeedData(games);

        return seedData;
    }

    private SeedData ExtractSeedData(List<GameEntity> games)
    {
        var seedData = new SeedData();

        foreach (var game in games)
        {
            ExtractRounds(game, seedData);
            seedData.Games.Add(game);
        }

        return seedData;
    }

    private void ExtractRounds(GameEntity game, SeedData seedData)
    {
        foreach (var round in game.Rounds)
        {
            round.GameId = game.Id;
            round.Game = game;
            ExtractCategories(round, seedData);
            seedData.Rounds.Add(round);
        }
    }

    private void ExtractCategories(RoundEntity round, SeedData seedData)
    {
        foreach (var category in round.Categories)
        {
            category.RoundId = round.Id;
            category.Round = round;
            ExtractQuestions(category, seedData);
            seedData.Categories.Add(category);
        }
    }

    private void ExtractQuestions(CategoryEntity category, SeedData seedData)
    {
        foreach (var question in category.Questions)
        {
            question.CategoryId = category.Id;
            question.Category = category;
            seedData.Questions.Add(question);
        }
    }
}
