using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.UnitTests.Providers.GameProviderTests;

public class GetById : IClassFixture<GameProviderFixture>
{
    private readonly GameProviderFixture _fixture;
    private readonly IGameProvider _provider;

    public GetById(GameProviderFixture fixture)
    {
        _fixture = fixture;
        _provider = _fixture.CreateInstance();
    }

    [Fact]
    public void GameProvider_GetById_IdDoesNotExist_Throws()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.GameRepository.Setup(x => x.GetById(id))
            .Returns((GameEntity)null!);

        // Act
        Action action = () => _provider.GetById(id);

        // Assert
        action.Should().Throw<NotFoundException>()
            .WithMessage($"GameId '{id}' was not found");
    }

    [Fact]
    public void GameProvider_GetById_IdExists_Good()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();
        var expected = _fixture.AutoFixture.Create<GameEntity>();

        _fixture.GameRepository.Setup(x => x.GetById(id))
            .Returns(expected);

        // Act
        var actual = _provider.GetById(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
