using TriviaGame.Api.Factories;
using TriviaGame.Api.Factories.Interfaces;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Models.Requests;

namespace TriviaGame.Api.UnitTests.Factories.CategoryFactoryTests;

public class CategoryFactoryFixture : BaseTestFixture<CategoryFactory>
{
    public Mock<IFactory<CreateQuestionRequest, QuestionEntity>> QuestionFactory;

    public CategoryFactoryFixture()
    {
        QuestionFactory = Repository.Create<IFactory<CreateQuestionRequest, QuestionEntity>>();
    }

    public override CategoryFactory CreateInstance() => new(QuestionFactory.Object);
}
