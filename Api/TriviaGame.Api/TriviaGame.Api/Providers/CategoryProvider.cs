using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.Providers;

/// <summary>
///     Handles business logic regarding Category data
/// </summary>
public class CategoryProvider : ICategoryProvider
{
    private readonly IRepository<CategoryEntity> _repository;

    public CategoryProvider(IRepository<CategoryEntity> repository)
    {
        _repository = repository;
    }

    public CategoryEntity GetById(string categoryId) =>
        _repository.GetById(categoryId)
        ?? throw new NotFoundException($"CategoryId '{categoryId}' was not found");

    public IEnumerable<CategoryEntity> GetByRoundId(string roundId)
    {
        var result = _repository.GetByParentId(roundId);

        return result?.Any() == true
            ? result
            : throw new NotFoundException($"Categories for {nameof(roundId)} '{roundId}' were not found");
    }
}
