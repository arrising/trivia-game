using Microsoft.EntityFrameworkCore;
using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data;

public class GameRepository : IRepository<GameEntity>
{
    private readonly IDbContext _context;

    public GameRepository(IDbContext context)
    {
        _context = context;
    }

    public GameEntity? GetById(Guid id) => _context.Games
        .Include(x => x.Rounds)
        .FirstOrDefault(x => x.Id == id);

    public IEnumerable<GameEntity> GetAll() => _context.Games.Include(x => x.Rounds);

    public async Task Update(GameEntity value)
    {
        var entity = await _context.Games.FindAsync(value.Id);
        if (entity != null)
        {
            _context.Entry(entity).CurrentValues.SetValues(value);
            await _context.SaveChangesAsync();
        }
    }

    // Game should never have a parent object
    public IEnumerable<GameEntity> GetByParentId(Guid id) =>
        throw new NotImplementedException("Game should never have a parent object");
}
