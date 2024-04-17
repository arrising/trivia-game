using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Providers.Interfaces;

public interface ICategoryProvider
{
    CategoryEntity GetById(string categoryId);
    IEnumerable<CategoryEntity> GetByRoundId(string roundId);
}
