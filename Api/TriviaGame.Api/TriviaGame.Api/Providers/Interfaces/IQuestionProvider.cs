using TriviaGame.Api.Models.Dtos;

namespace TriviaGame.Api.Providers.Interfaces;

public interface IQuestionProvider
{
    QuestionDto GetById(string questionId);
    IEnumerable<QuestionDto> GetByCategoryId(string categoryId);
}
