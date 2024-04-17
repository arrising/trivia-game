using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Mediators.GameMediatorTests;

public class GetGamesTests : IClassFixture<GameMediatorFixture>
{
    private readonly GameMediatorFixture _fixture;
    private readonly IGameMediator _mediator;

    public GetGamesTests(GameMediatorFixture fixture)
    {
        _fixture = fixture;
        _mediator = fixture.CreateInstance();
    }

    [Fact]
    public void GameMediator_GetGames_Good()
    {
        // Arrange
        var expected = _fixture.AutoFixture.CreateMany<GameEntity>();

        _fixture.GameRepository.Setup(x => x.GetAll())
            .Returns(expected);

        // Act
        var actual = _mediator.GetGames();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
