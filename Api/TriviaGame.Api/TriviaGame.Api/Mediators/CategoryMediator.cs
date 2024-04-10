using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models;
using TriviaGame.Api.Validators.Interfaces;

namespace TriviaGame.Api.Mediators;

public class CategoryMediator : ICategoryMediator
{
    private readonly IRepository<Category> _repository;
    private readonly IIdValidator _validator;

    public CategoryMediator(IRepository<Category> repository, IIdValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public Category GetById(string categoryId)
    {
        if (_validator.TryGetValidationException(categoryId, nameof(categoryId), out var exception))
        {
            throw exception;
        }

        return _repository.GetById(categoryId)
               ?? throw new NotFoundException($"CategoryId '{categoryId}' was not found");
    }

    public IEnumerable<Category> GetByRoundId(string roundId)
    {
        if (_validator.TryGetValidationException(roundId, nameof(roundId), out var exception))
        {
            throw exception;
        }

        var result = _repository.GetByParentId(roundId);

        return result?.Any() == true
            ? result
            : throw new NotFoundException($"Categories for {nameof(roundId)} '{roundId}' were not found");
    }
}
