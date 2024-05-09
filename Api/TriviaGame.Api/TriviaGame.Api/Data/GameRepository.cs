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

    public async Task<GameEntity> Add(GameEntity value, CancellationToken token)
    {
        //TODO: Should Provider or repository be responsible for creating IDs
        _context.Games.Add(value);
        AddRounds(value.Rounds);

        await _context.SaveChangesAsync(token);
        return value;
    }

    private void AddRounds(IEnumerable<RoundEntity> rounds)
    {
        if (rounds.Any())
        {
            _context.Rounds.AddRange(rounds);
            var categories = rounds.SelectMany(x => x.Categories);
            AddCategories(categories);
        }
    }

    private void AddCategories(IEnumerable<CategoryEntity> categories)
    {
        if (categories.Any())
        {
            _context.Categories.AddRange(categories);
            var questions = categories.SelectMany(x => x.Questions);
            AddQuestions(questions);
        }
    }

    private void AddQuestions(IEnumerable<QuestionEntity> questions)
    {
        if (questions.Any())
        {
            _context.Questions.AddRange(questions);
        }
    }

    public GameEntity? GetById(Guid id) => _context.Games
        .Include(x => x.Rounds)
        .FirstOrDefault(x => x.Id == id);

    public IEnumerable<GameEntity> GetAll() => _context.Games.Include(x => x.Rounds);

    // Game should never have a parent object
    public IEnumerable<GameEntity> GetByParentId(Guid id) =>
        throw new NotImplementedException("Game should never have a parent object");
}
