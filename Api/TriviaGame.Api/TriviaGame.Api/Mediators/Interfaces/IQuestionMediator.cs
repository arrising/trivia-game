using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Mediators.Interfaces;

public interface IQuestionMediator
{
    QuestionEntity GetById(string questionId);
    IEnumerable<QuestionEntity> GetByCategoryId(string categoryId);
}
