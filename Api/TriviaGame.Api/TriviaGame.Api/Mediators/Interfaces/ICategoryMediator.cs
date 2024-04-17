using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Mediators.Interfaces;

public interface ICategoryMediator
{
    CategoryEntity GetById(string categoryId);
    IEnumerable<CategoryEntity> GetByRoundId(string roundId);
}
