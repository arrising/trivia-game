using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.Data.InMemoryDb;

public class RoundRepository : IRepository<Round>
{
    private readonly TriviaGameDbContext _context;

    public RoundRepository(TriviaGameDbContext context)
    {
        _context = context;
    }

    public Round? GetById(string id) =>
        _context.Rounds.SingleOrDefault(x => x.Id == id);

    public IEnumerable<Round> GetByParentId(string gameId) =>
        _context.Rounds.Where(x => x.GameId == gameId);

    public IEnumerable<Round> GetAll() => _context.Rounds;
}
