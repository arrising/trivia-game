using TriviaGame.Api.Factories.Interfaces;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Models.Requests;

namespace TriviaGame.Api.Factories;

public class QuestionFactory : IFactory<CreateQuestionRequest, QuestionEntity>
{
    public QuestionEntity Create(CreateQuestionRequest options) =>
        new()
        {
            Id = Guid.NewGuid(),
            CategoryId = options.CategoryId,
            Ask = $"{options.CategoryName}_Question{options.QuestionNumber}",
            Answer = $"{options.CategoryName}_Answer{options.QuestionNumber}",
            Value = options.QuestionValue
        };
}
