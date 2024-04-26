using TriviaGame.Api.Factories;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Models.Requests;

namespace TriviaGame.Api.UnitTests.Factories.GameFactoryTests;

public class Create : IClassFixture<GameFactoryFixture>
{
    private readonly GameFactory _factory;
    private readonly GameFactoryFixture _fixture;

    public Create(GameFactoryFixture fixture)
    {
        _fixture = fixture;
        _factory = _fixture.CreateInstance();
    }

    [Fact]
    public void GameFactory_Create_Good()
    {
        var request = _fixture.AutoFixture.Create<CreateGameRequest>();
        var name = "New Game";
        var rounds = Enumerable.Range(1, request.RoundsPerGame).ToList().SetupTestCases(roundNumber =>
        {
            var roundRequest = new CreateRoundRequest
            {
                GameName = name,
                RoundNumber = roundNumber,
                CategoriesPerRound = request.CategoriesPerRound,
                QuestionsPerCategory = request.QuestionsPerCategory,
                QuestionBaseValue = request.QuestionBaseValue * roundNumber
            };
            var entity = _fixture.AutoFixture.Create<RoundEntity>();

            // TODO: Setup works as expected, bit is hard to diagnose if there are any errors
            _fixture.RoundFactory.Setup(x => x.Create(It.Is<CreateRoundRequest>(match =>
                    match.IsEquivalentTo(roundRequest, options => options.Excluding(prop => prop.GameId)))))
                .Returns(entity);

            return entity;
        }).ToList();

        var expected = new GameEntity
        {
            ValueSymbol = request.ValueSymbol,
            Name = name,
            Rounds = rounds
        };

        var actual = _factory.Create(request);

        actual.Should().BeEquivalentTo(expected, config => config.Excluding(x => x.Id));
        actual.Id.Should().NotBe(Guid.Empty);
    }
}
