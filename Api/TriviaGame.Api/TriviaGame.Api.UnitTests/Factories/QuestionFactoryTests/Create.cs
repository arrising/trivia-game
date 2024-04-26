using TriviaGame.Api.Factories;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Models.Requests;

namespace TriviaGame.Api.UnitTests.Factories.QuestionFactoryTests;

public class Create : IClassFixture<QuestionFactoryFixture>
{
    private readonly QuestionFactory _factory;
    private readonly QuestionFactoryFixture _fixture;

    public Create(QuestionFactoryFixture fixture)
    {
        _fixture = fixture;
        _factory = _fixture.CreateInstance();
    }

    [Fact]
    public void QuestionFactory_Constructor_Good()
    {
        var request = _fixture.AutoFixture.Create<CreateQuestionRequest>();
        var expected = new QuestionEntity
        {
            CategoryId = request.CategoryId,
            Ask = $"{request.CategoryName}_Question{request.QuestionNumber}",
            Answer = $"{request.CategoryName}_Answer{request.QuestionNumber}",
            Value = request.QuestionValue
        };

        var actual = _factory.Create(request);

        actual.Should().BeEquivalentTo(expected, config => config.Excluding(x => x.Id));
        actual.Id.Should().NotBe(Guid.Empty);
    }
}
