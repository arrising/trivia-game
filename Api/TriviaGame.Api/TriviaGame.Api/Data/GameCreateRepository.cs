using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data;

public class GameCreateRepository : IComplexEntityRepository<GameEntity>
{
    private readonly IDbContext _context;

    public GameCreateRepository(IDbContext context)
    {
        _context = context;
    }

    public async Task<GameEntity> Add(GameEntity value, CancellationToken token)
    {
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
}
