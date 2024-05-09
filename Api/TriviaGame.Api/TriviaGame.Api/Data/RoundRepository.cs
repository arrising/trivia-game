using Microsoft.EntityFrameworkCore;
using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data;

public class RoundRepository : IRepository<RoundEntity>
{
    private readonly IDbContext _context;

    public RoundRepository(IDbContext context)
    {
        _context = context;
    }

    public Task<RoundEntity> Add(RoundEntity value, CancellationToken token) => throw new NotImplementedException();

    public RoundEntity? GetById(Guid id) =>
        _context.Rounds
            .Include(x => x.Categories)
            .FirstOrDefault(x => x.Id == id);

    public IEnumerable<RoundEntity> GetByParentId(Guid gameId) =>
        _context.Rounds
            .Include(x => x.Categories)
            .Where(x => x.GameId == gameId);

    public IEnumerable<RoundEntity> GetAll() => _context.Rounds.Include(x => x.Categories);
}
