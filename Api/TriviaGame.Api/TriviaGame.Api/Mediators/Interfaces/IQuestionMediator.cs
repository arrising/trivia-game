using TriviaGame.Api.Models;

namespace TriviaGame.Api.Mediators.Interfaces;

public interface IQuestionMediator
{
    Question GetById(string questionId);
    IEnumerable<Question> GetByCategoryId(string categoryId);
}
