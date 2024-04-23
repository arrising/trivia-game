using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.Providers;

/// <summary>
///     Handles business logic regarding Question data
/// </summary>
public class QuestionProvider : IQuestionProvider
{
    private readonly IRepository<QuestionEntity> _repository;

    public QuestionProvider(IRepository<QuestionEntity> repository)
    {
        _repository = repository;
    }

    public QuestionDto GetById(string questionId)
    {
        var entity = _repository.GetById(questionId);
        return entity != null
            ? new QuestionDto(entity)
            : throw new NotFoundException($"QuestionId '{questionId}' was not found");
    }

    public IEnumerable<QuestionDto> GetByCategoryId(string categoryId)
    {
        var entities = _repository.GetByParentId(categoryId);

        return entities?.Any() == true
            ? entities.Select(entity => new QuestionDto(entity))
            : throw new NotFoundException($"Questions for {nameof(categoryId)} '{categoryId}' were not found");
    }
}
