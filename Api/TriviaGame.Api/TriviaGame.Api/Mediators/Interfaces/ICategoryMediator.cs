using TriviaGame.Api.Models;

namespace TriviaGame.Api.Mediators.Interfaces;

public interface ICategoryMediator
{
    Category GetById(string categoryId);
    IEnumerable<Category> GetByRoundId(string roundId);
}
