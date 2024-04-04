using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models;
using TriviaGame.Api.Services.Interfaces;

namespace TriviaGame.Api.UnitTests.Services.GameServiceTests;

public class GetById : IClassFixture<GameServiceFixture>
{
    private readonly GameServiceFixture _fixture;
    private readonly IGameService _service;

    public GetById(GameServiceFixture fixture)
    {
        _fixture = fixture;
        _service = _fixture.CreateInstance();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("     ")]
    public void GameService_GetById_IdMissing_Throws(string? gameId)
    {
        // Act
        Action action = () => _service.GetById(gameId);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("game id must have a value (Parameter 'gameId')");
    }

    [Fact]
    public void GameService_GetById_IdDoesNotExist_Throws()
    {
        // Arrange
        var gameId = _fixture.AutoFixture.Create<string>();

        _fixture.GameRepository.Setup(x => x.GetById(gameId))
            .Returns((Game)null!);

        // Act
        Action action = () => _service.GetById(gameId);

        // Assert
        action.Should().Throw<NotFoundException>()
            .WithMessage($"GameId '{gameId}' was not found");
    }

    [Fact]
    public void GameService_GetById_IdExists_Good()
    {
        // Arrange
        var gameId = _fixture.AutoFixture.Create<string>();
        var expected = _fixture.AutoFixture.Create<Game>();

        _fixture.GameRepository.Setup(x => x.GetById(gameId))
            .Returns(expected);

        // Act
        var actual = _service.GetById(gameId);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
