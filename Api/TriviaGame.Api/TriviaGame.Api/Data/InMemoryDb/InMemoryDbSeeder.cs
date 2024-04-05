using System.Text.Json;
using TriviaGame.Api.Data.InMemoryDb.Configuration;
using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models;
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
        var games = JsonSerializer.Deserialize<List<Game>>(fileStream, options) ?? new List<Game>();

        var rounds = new List<Round>();
        var categories = new List<Category>();

        foreach (var game in games)
        {
            foreach (var round in game.Rounds)
            {
                round.GameId = game.Id;
                foreach (var category in round.Categories)
                {
                    category.RoundId = round.Id;
                    categories.Add(category);
                }
                rounds.Add(round);
            }
        }

        return new SeedData
        {
            Categories = categories,
            Games = games,
            Rounds = rounds
        };
    }
}

public class SeedData
{
    public List<Category> Categories { get; set; }
    public List<Game> Games { get; set; }
    public List<Round> Rounds { get; set; }
}