using System.Text.Json;
using System.Xml.Linq;
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

        foreach (var value in games)
        {
            var rounds = ExtractRounds(value, seedData);
            var game = new GameEntity(value)
            {
                Rounds = rounds
            };
            seedData.Games.Add(game);
        }

        return seedData;
    }

    private IEnumerable<RoundEntity> ExtractRounds(GameEntity game, SeedData seedData)
    {
        var rounds = new List<RoundEntity>();
        foreach (var value in game.Rounds)
        {
            var categories = ExtractCategories(value, seedData);
            var round = new RoundEntity(value)
            {
                GameId = game.Id,
                Game = game,
                Categories = categories
            };
            seedData.Rounds.Add(round);
            rounds.Add(round);
        }
        return rounds;
    }

    private IEnumerable<CategoryEntity> ExtractCategories(RoundEntity round, SeedData seedData)
    {
        var categories = new List<CategoryEntity>();
        foreach (var value in round.Categories)
        {
            var questions = ExtractQuestions(value, seedData);
            var category = new CategoryEntity(value)
            {
                RoundId = round.Id,
                Round = round,
                Questions = questions
            };
            seedData.Categories.Add(category);
            categories.Add(category);
        }
        return categories;
    }

    private IEnumerable<QuestionEntity> ExtractQuestions(CategoryEntity category, SeedData seedData)
    {
        var questions = new List<QuestionEntity>();
        foreach (var value in category.Questions)
        {
            var question = new QuestionEntity(value)
            {
                CategoryId = category.Id,
                Category = category
            };
            seedData.Questions.Add(question);
            questions.Add(question);
        }
        return questions;
    }
}
