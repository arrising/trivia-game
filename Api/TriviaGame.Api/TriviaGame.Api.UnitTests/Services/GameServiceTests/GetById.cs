﻿using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models;
using TriviaGame.Api.Services.Interfaces;
using TriviaGame.Api.UnitTests.TestHelpers;

namespace TriviaGame.Api.UnitTests.Services.GameServiceTests;

public class GetById : IClassFixture<GameServiceFixture>
{
    private readonly GameServiceFixture _fixture;
    private readonly IGameService _service;
    private readonly string _idName = "gameId";

    public GetById(GameServiceFixture fixture)
    {
        _fixture = fixture;
        _service = _fixture.CreateInstance();
    }

    [Fact]
    public void GameService_GetById_HasValidationError_Throws()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.IdValidator.ReturnsWithException(id, _idName);

        // Act
        Action action = () => _service.GetById(id);

        // Assert
        action.Should().Throw<TestException>();
    }

    [Fact]
    public void GameService_GetById_IdDoesNotExist_Throws()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.IdValidator.ReturnsAsValid(id, _idName);
        _fixture.GameRepository.Setup(x => x.GetById(id))
            .Returns((Game)null!);

        // Act
        Action action = () => _service.GetById(id);

        // Assert
        action.Should().Throw<NotFoundException>()
            .WithMessage($"GameId '{id}' was not found");
    }

    [Fact]
    public void GameService_GetById_IdExists_Good()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();
        var expected = _fixture.AutoFixture.Create<Game>();

        _fixture.IdValidator.ReturnsAsValid(id, _idName);
        _fixture.GameRepository.Setup(x => x.GetById(id))
            .Returns(expected);

        // Act
        var actual = _service.GetById(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
