using TriviaGame.Api.Models;
using TriviaGame.Api.Services.Interfaces;

namespace TriviaGame.Api.UnitTests.Services.GameServiceTests;

public class GetGamesTests : IClassFixture<GameServiceFixture>
{
    private readonly GameServiceFixture _fixture;
    private readonly IGameService _service;

    public GetGamesTests(GameServiceFixture fixture)
    {
        _fixture = fixture;
        _service = fixture.CreateInstance();
    }

    [Fact]
    public void GameService_GetGames_Good()
    {
        // Arrange
        var expected = _fixture.AutoFixture.CreateMany<Game>();

        _fixture.GameRepository.Setup(x => x.GetAll())
            .Returns(expected);

        // Act
        var actual = _service.GetGames();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
