using System.Text.Json;
using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TriviaGame.Api.Data.InMemoryDb.Configuration;

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
            var games = LoadGames();
            _context.Games.AddRange(games);

            await _context.SaveChangesAsync();
        }
        else
        {
            // Assures a task is always completed.
            await Task.CompletedTask;
        }
    }

    private IEnumerable<Game> LoadGames()
    {
        using var fileStream = new FileStream(InMemoryDbConstants.SeedDataFile, FileMode.Open);
        using var streamReader = new StreamReader(fileStream);
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var games = JsonSerializer.Deserialize<List<Game>>(fileStream, options);

        return games?.ToList() ?? new List<Game>();
    }
}
