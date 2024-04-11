using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.Mediators;

/// <summary>
///     Handles business logic regarding Category data
/// </summary>
public class CategoryMediator : ICategoryMediator
{
    private readonly IRepository<Category> _repository;

    public CategoryMediator(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public Category GetById(string categoryId) =>
        _repository.GetById(categoryId)
        ?? throw new NotFoundException($"CategoryId '{categoryId}' was not found");

    public IEnumerable<Category> GetByRoundId(string roundId)
    {
        var result = _repository.GetByParentId(roundId);

        return result?.Any() == true
            ? result
            : throw new NotFoundException($"Categories for {nameof(roundId)} '{roundId}' were not found");
    }
}
