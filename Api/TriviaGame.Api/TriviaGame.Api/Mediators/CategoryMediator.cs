using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Mediators;

/// <summary>
///     Handles business logic regarding Category data
/// </summary>
public class CategoryMediator : ICategoryMediator
{
    private readonly IRepository<CategoryEntity> _repository;

    public CategoryMediator(IRepository<CategoryEntity> repository)
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
