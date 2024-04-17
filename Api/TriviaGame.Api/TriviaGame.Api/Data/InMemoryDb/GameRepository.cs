using Microsoft.EntityFrameworkCore;
using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data.InMemoryDb;

public class GameRepository : IRepository<GameEntity>
{
    private readonly TriviaGameDbContext _context;

    public GameRepository(TriviaGameDbContext context)
    {
        _context = context;
    }

    public GameEntity? GetById(string id) => _context.Games
        .Include(x => x.Rounds)
        .FirstOrDefault(x => x.Id == id);

    public IEnumerable<GameEntity> GetAll() => _context.Games.Include(x => x.Rounds);

    // Game should never have a parent object
    public IEnumerable<GameEntity> GetByParentId(string id) =>
        throw new NotImplementedException("Game should never have a parent object");
}
