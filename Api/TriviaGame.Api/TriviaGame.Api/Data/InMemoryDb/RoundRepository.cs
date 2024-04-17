using Microsoft.EntityFrameworkCore;
using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data.InMemoryDb;

public class RoundRepository : IRepository<RoundEntity>
{
    private readonly TriviaGameDbContext _context;

    public RoundRepository(TriviaGameDbContext context)
    {
        _context = context;
    }

    public RoundEntity? GetById(string id) =>
        _context.Rounds
            .Include(x => x.Categories)
            .FirstOrDefault(x => x.Id == id);

    public IEnumerable<RoundEntity> GetByParentId(string gameId) =>
        _context.Rounds
            .Include(x => x.Categories)
            .Where(x => x.GameId == gameId);

    public IEnumerable<RoundEntity> GetAll() => _context.Rounds.Include(x => x.Categories);
}
