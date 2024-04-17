using System.Text.Json;
using TriviaGame.Api.Data.InMemoryDb.Configuration;
using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TriviaGame.Api.Data.InMemoryDb;

public class InMemoryDbSeeder : IDbSeeder
{
    private readonly TriviaGameDbContext _context;

    public InMemoryDbSeeder(TriviaGameDbContext context)
    {
        _context = context;
    }

    public async Task Seed()
    {
        if (!_context.Games.Any())
        {
            var data = LoadGames();

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

    private SeedData LoadGames()
    {
        using var fileStream = new FileStream(InMemoryDbConstants.SeedDataFile, FileMode.Open);
        using var streamReader = new StreamReader(fileStream);
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var games = JsonSerializer.Deserialize<List<GameEntity>>(fileStream, options) ?? new List<GameEntity>();

        var seedData = ExtractSeedData(games);

        return seedData;
    }

    public SeedData ExtractSeedData(List<GameEntity> games)
    {
        var seedData = new SeedData();

        foreach (var game in games)
        {
            ExtractRounds(game, seedData);
            seedData.Games.Add(game);
        }

        return seedData;
    }

    public void ExtractRounds(GameEntity game, SeedData seedData)
    {
        foreach (var round in game.Rounds)
        {
            round.GameId = game.Id;
            ExtractCategories(round, seedData);
            seedData.Rounds.Add(round);
        }
    }

    public void ExtractCategories(RoundEntity round, SeedData seedData)
    {
        foreach (var category in round.Categories)
        {
            category.RoundId = round.Id;
            ExtractQuestions(category, seedData);
            seedData.Categories.Add(category);
        }
    }

    public void ExtractQuestions(CategoryEntity category, SeedData seedData)
    {
        foreach (var question in category.Questions)
        {
            question.CategoryId = category.Id;
            seedData.Questions.Add(question);
        }
    }
}

public class SeedData
{
    public List<CategoryEntity> Categories { get; set; } = new();
    public List<GameEntity> Games { get; set; } = new();
    public List<RoundEntity> Rounds { get; set; } = new();
    public List<QuestionEntity> Questions { get; set; } = new();
}
