using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Dtos;
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

    public CategoryDto GetById(string categoryId)
    {
        var entity = _repository.GetById(categoryId);
        return entity != null
            ? new CategoryDto(entity)
            : throw new NotFoundException($"CategoryId '{categoryId}' was not found");
    }

    public IEnumerable<CategoryDto> GetByRoundId(string roundId)
    {
        var entities = _repository.GetByParentId(roundId);

        return entities?.Any() == true
            ? entities.Select(entity => new CategoryDto(entity))
            : throw new NotFoundException($"Categories for {nameof(roundId)} '{roundId}' were not found");
    }
}
