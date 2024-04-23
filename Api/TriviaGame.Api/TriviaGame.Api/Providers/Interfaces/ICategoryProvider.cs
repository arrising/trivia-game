using TriviaGame.Api.Models.Dtos;

namespace TriviaGame.Api.Providers.Interfaces;

public interface ICategoryProvider
{
    CategoryDto GetById(string categoryId);
    IEnumerable<CategoryDto> GetByRoundId(string roundId);
}
