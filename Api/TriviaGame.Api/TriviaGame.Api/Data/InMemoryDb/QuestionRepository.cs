using Microsoft.EntityFrameworkCore;
using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data.InMemoryDb;

public class QuestionRepository : IRepository<QuestionEntity>
{
    private TriviaGameDbContext _context;

    public QuestionRepository(TriviaGameDbContext context)
    {
        _context = context;
    }

    public QuestionEntity? GetById(string id) => _context.Questions
        .Include(x => x.Alternatives)
        .FirstOrDefault(x => x.Id == id);

    public IEnumerable<QuestionEntity> GetByParentId(string id) => throw new NotImplementedException();

    public IEnumerable<QuestionEntity> GetAll() => _context.Questions
        .Include(x => x.Alternatives);
}
