using Microsoft.EntityFrameworkCore;
using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data.InMemoryDb;

public class CategoryRepository : IRepository<CategoryEntity>
{
    private readonly TriviaGameDbContext _context;

    public CategoryRepository(TriviaGameDbContext context)
    {
        _context = context;
    }

    public CategoryEntity? GetById(string id) =>
        _context.Categories
            .Include(x => x.Questions)
            .FirstOrDefault(x => x.Id == id);

    public IEnumerable<CategoryEntity> GetByParentId(string id) =>
        _context.Categories
            .Include(x => x.Questions)
            .Where(x => x.RoundId == id);

    public IEnumerable<CategoryEntity> GetAll() => _context.Categories;
}
