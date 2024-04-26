using TriviaGame.Api.Factories.Interfaces;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Models.Requests;

namespace TriviaGame.Api.Factories;

public class CategoryFactory : IFactory<CreateCategoryRequest, CategoryEntity>
{
    private readonly IFactory<CreateQuestionRequest, QuestionEntity> _questionFactory;

    public CategoryFactory(IFactory<CreateQuestionRequest, QuestionEntity> questionFactory)
    {
        _questionFactory = questionFactory;
    }

    public CategoryEntity Create(CreateCategoryRequest options)
    {
        var id = Guid.NewGuid();
        var name = $"{options.RoundName}_Category{options.CategoryNumber}";
        var questions = Enumerable.Range(1, options.QuestionsPerCategory).ToList().Select(number =>
        {
            var categoryRequest = new CreateQuestionRequest
            {
                CategoryId = id,
                CategoryName = name,
                QuestionNumber = number,
                QuestionValue = options.QuestionBaseValue * number
            };
            return _questionFactory.Create(categoryRequest);
        }).ToList();

        return new CategoryEntity
        {
            Id = id,
            Name = name,
            RoundId = options.RoundId,
            Questions = questions
        };
    }
}
