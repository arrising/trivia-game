using Microsoft.EntityFrameworkCore;
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

    public Game? GetById(string id) => _context.Games
        .Include(x => x.Rounds)
        .FirstOrDefault(x => x.Id == id);

    public IEnumerable<Game> GetAll() => _context.Games.Include(x => x.Rounds);

    // Game should never have a parent object
    public IEnumerable<Game> GetByParentId(string id) =>
        throw new NotImplementedException("Game should never have a parent object");
}
