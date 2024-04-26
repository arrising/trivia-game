using TriviaGame.Api.Factories;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Models.Requests;

namespace TriviaGame.Api.UnitTests.Factories.RoundFactoryTests;

public class Create : IClassFixture<RoundFactoryFixture>
{
    private readonly RoundFactory _factory;
    private readonly RoundFactoryFixture _fixture;

    public Create(RoundFactoryFixture fixture)
    {
        _fixture = fixture;
        _factory = _fixture.CreateInstance();
    }

    [Fact]
    public void RoundFactory_Create_Good()
    {
        var request = _fixture.AutoFixture.Create<CreateRoundRequest>();
        var name = $"{request.GameName}_Round{request.RoundNumber}";
        var categories = Enumerable.Range(1, request.CategoriesPerRound).ToList().SetupTestCases(number =>
        {
            var categoryRequest = new CreateCategoryRequest
            {
                RoundName = name,
                CategoryNumber = number,
                QuestionsPerCategory = request.CategoriesPerRound,
                QuestionBaseValue = request.QuestionBaseValue
            };
            var entity = _fixture.AutoFixture.Create<CategoryEntity>();

            // TODO: Setup works as expected, bit is hard to diagnose if there are any errors
            _fixture.CategoryFactory.Setup(x => x.Create(It.Is<CreateCategoryRequest>(match =>
                    match.IsEquivalentTo(categoryRequest, options => options.Excluding(prop => prop.RoundId)))))
                .Returns(entity);

            return entity;
        }).ToList();

        var expected = new RoundEntity
        {
            Type = name,
            GameId = request.GameId,
            Categories = categories
        };

        var actual = _factory.Create(request);

        actual.Should().BeEquivalentTo(expected, config => config.Excluding(x => x.Id));
        actual.Id.Should().NotBe(Guid.Empty);
    }
}
