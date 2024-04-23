using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.UnitTests.Providers.GameProviderTests;

public class GetGamesTests : IClassFixture<GameProviderFixture>
{
    private readonly GameProviderFixture _fixture;
    private readonly IGameProvider _provider;

    public GetGamesTests(GameProviderFixture fixture)
    {
        _fixture = fixture;
        _provider = fixture.CreateInstance();
    }

    [Fact]
    public void GameProvider_GetGames_Good()
    {
        // Arrange
        var entities = _fixture.AutoFixture.CreateMany<GameEntity>();
        var expected = entities.Select(entity => new GameDto(entity));

        _fixture.GameRepository.Setup(x => x.GetAll())
            .Returns(entities);

        // Act
        var actual = _provider.GetGames();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
