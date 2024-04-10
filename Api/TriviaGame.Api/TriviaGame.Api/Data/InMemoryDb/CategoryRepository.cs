using Microsoft.EntityFrameworkCore;
using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.Data.InMemoryDb;

public class CategoryRepository : IRepository<Category>
{
    private readonly TriviaGameDbContext _context;

    public CategoryRepository(TriviaGameDbContext context)
    {
        _context = context;
    }

    public Category? GetById(string id) =>
        _context.Categories
            .Include(x => x.Questions)
            .FirstOrDefault(x => x.Id == id);

    public IEnumerable<Category> GetByParentId(string id) =>
        _context.Categories
            .Include(x => x.Questions)
            .Where(x => x.RoundId == id);

    public IEnumerable<Category> GetAll() => _context.Categories;
}
