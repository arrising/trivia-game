using TriviaGame.Api.Data.Interfaces;

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
            var data = new SeedDataFactory().BuildGameSeedData();

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
