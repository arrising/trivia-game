using TriviaGame.Api.Data.Configuration;
using TriviaGame.Api.Data.Interfaces;

namespace TriviaGame.Api.Data.SeedData;

public class DbSeeder : IDbSeeder
{
    private readonly IDbContext _context;
    private readonly DatabaseConfiguration _configuration;

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
            var data = new SeedDataFactory().BuildGameSeedData(_configuration.SeedFilePath);

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
}
