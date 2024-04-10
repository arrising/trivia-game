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
        _context.Categories.FirstOrDefault(x => x.Id == id);

    public IEnumerable<Category> GetByParentId(string id) =>
        _context.Categories.Where(x => x.RoundId == id);

    public IEnumerable<Category> GetAll() => _context.Categories;
}
