using TriviaGame.Api.Factories;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Models.Requests;

namespace TriviaGame.Api.UnitTests.Factories.CategoryFactoryTests;

public class Create : IClassFixture<CategoryFactoryFixture>
{
    private readonly CategoryFactory _factory;
    private readonly CategoryFactoryFixture _fixture;

    public Create(CategoryFactoryFixture fixture)
    {
        _fixture = fixture;
        _factory = _fixture.CreateInstance();
    }

    [Fact]
    public void CategoryFactory_Constructor_Good()
    {
        var request = _fixture.AutoFixture.Create<CreateCategoryRequest>();
        var name = $"{request.RoundName}_Category{request.CategoryNumber}";
        var questions = Enumerable.Range(1, request.QuestionsPerCategory).ToList()
            .SetupTestCases(number =>
            {
                var questionRequest = new CreateQuestionRequest
                {
                    CategoryName = name,
                    QuestionNumber = number,
                    QuestionValue = request.QuestionBaseValue * number
                };
                var entity = _fixture.AutoFixture.Create<QuestionEntity>();

                // TODO: Setup works as expected, bit is hard to diagnose if there are any errors
                _fixture.QuestionFactory.Setup(x => x.Create(It.Is<CreateQuestionRequest>(match =>
                        match.IsEquivalentTo(questionRequest, options => options.Excluding(prop => prop.CategoryId)))))
                    .Returns(entity);

                return entity;
            }).ToList();

        var expected = new CategoryEntity
        {
            RoundId = request.RoundId,
            Name = name,
            Questions = questions
        };

        var actual = _factory.Create(request);

        actual.Should().BeEquivalentTo(expected, config => config.Excluding(x => x.Id));
        actual.Id.Should().NotBe(Guid.Empty);
    }
}
