using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.Data.InMemoryDb.Configuration;

public class QuestionRepository : IRepository<Question>
{
    private readonly TriviaGameDbContext _context;

    public QuestionRepository(TriviaGameDbContext context)
    {
        _context = context;
    }

    public Question? GetById(string id) =>
        _context.Questions.FirstOrDefault(x => x.Id == id);

    public IEnumerable<Question> GetByParentId(string id) =>
        _context.Questions.Where(x => x.CategoryId == id);

    public IEnumerable<Question> GetAll() => _context.Questions;
}
