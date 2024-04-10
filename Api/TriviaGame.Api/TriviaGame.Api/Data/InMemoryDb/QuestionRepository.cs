using Microsoft.EntityFrameworkCore;
using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.Data.InMemoryDb;

public class QuestionRepository : IRepository<Question>
{
    private TriviaGameDbContext _context;

    public QuestionRepository(TriviaGameDbContext context)
    {
        _context = context;
    }

    public Question? GetById(string id) => _context.Questions
        .Include(x => x.Alternatives)
        .FirstOrDefault(x => x.Id == id);

    public IEnumerable<Question> GetByParentId(string id) => throw new NotImplementedException();

    public IEnumerable<Question> GetAll() => _context.Questions
        .Include(x => x.Alternatives);
}
