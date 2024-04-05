using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models;
using TriviaGame.Api.UnitTests.TestHelpers;

namespace TriviaGame.Api.UnitTests.Mediators.GameMediatorTests;

public class GetById : IClassFixture<GameMediatorFixture>
{
    private readonly GameMediatorFixture _fixture;
    private readonly IGameMediator _mediator;
    private readonly string _idName = "gameId";

    public GetById(GameMediatorFixture fixture)
    {
        _fixture = fixture;
        _mediator = _fixture.CreateInstance();
    }

    [Fact]
    public void GameMediator_GetById_HasValidationError_Throws()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.IdValidator.ReturnsWithException(id, _idName);

        // Act
        Action action = () => _mediator.GetById(id);

        // Assert
        action.Should().Throw<TestException>();
    }

    [Fact]
    public void GameMediator_GetById_IdDoesNotExist_Throws()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.IdValidator.ReturnsAsValid(id, _idName);
        _fixture.GameRepository.Setup(x => x.GetById(id))
            .Returns((Game)null!);

        // Act
        Action action = () => _mediator.GetById(id);

        // Assert
        action.Should().Throw<NotFoundException>()
            .WithMessage($"GameId '{id}' was not found");
    }

    [Fact]
    public void GameMediator_GetById_IdExists_Good()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();
        var expected = _fixture.AutoFixture.Create<Game>();

        _fixture.IdValidator.ReturnsAsValid(id, _idName);
        _fixture.GameRepository.Setup(x => x.GetById(id))
            .Returns(expected);

        // Act
        var actual = _mediator.GetById(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
