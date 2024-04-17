using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Exceptions;
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

    public QuestionEntity GetById(string questionId) =>
        _repository.GetById(questionId)
        ?? throw new NotFoundException($"QuestionId '{questionId}' was not found");

    public IEnumerable<QuestionEntity> GetByCategoryId(string categoryId)
    {
        var result = _repository.GetByParentId(categoryId);

        return result?.Any() == true
            ? result
            : throw new NotFoundException($"Questions for {nameof(categoryId)} '{categoryId}' were not found");
    }
}
