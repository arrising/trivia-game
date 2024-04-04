using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.Data.InMemoryDb;

public class GameRepository : IRepository<Game>
{
    private readonly TriviaGameDbContext _context;

    public GameRepository(TriviaGameDbContext context)
    {
        _context = context;
    }

    public Game GetById(string gameId) => _context.Games.SingleOrDefault(x => x.Id == gameId)!;

    public IEnumerable<Game> GetAll() => _context.Games;
}
