using Microsoft.EntityFrameworkCore;
using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data;

public class CategoryRepository : IRepository<CategoryEntity>
{
    private readonly IDbContext _context;

    public CategoryRepository(IDbContext context)
    {
        _context = context;
    }

    public Task<CategoryEntity> Add(CategoryEntity value, CancellationToken token) => throw new NotImplementedException();

    public CategoryEntity? GetById(Guid id) =>
        _context.Categories
            .Include(x => x.Questions)
            .FirstOrDefault(x => x.Id == id);

    public IEnumerable<CategoryEntity> GetByParentId(Guid id) =>
        _context.Categories
            .Include(x => x.Questions)
            .Where(x => x.RoundId == id);

    public IEnumerable<CategoryEntity> GetAll() => _context.Categories;
}
