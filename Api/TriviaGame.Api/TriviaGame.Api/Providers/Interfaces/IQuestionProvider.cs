using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Providers.Interfaces;

public interface IQuestionProvider
{
    QuestionEntity GetById(string questionId);
    IEnumerable<QuestionEntity> GetByCategoryId(string categoryId);
}
