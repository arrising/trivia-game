using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models;
using TriviaGame.Api.Services.Interfaces;
using TriviaGame.Api.UnitTests.TestHelpers;

namespace TriviaGame.Api.UnitTests.Services.RoundServiceTests;

public class GetById : IClassFixture<RoundServiceFixture>
{
    private readonly RoundServiceFixture _fixture;
    private readonly IRoundService _service;
    private readonly string _idName = "roundId";

    public GetById(RoundServiceFixture fixture)
    {
        _fixture = fixture;
        _service = _fixture.CreateInstance();
    }

    [Fact]
    public void RoundService_GetById_HasValidationError_Throws()
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
    public void RoundService_GetById_IdDoesNotExist_Throws()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.IdValidator.ReturnsAsValid(id, _idName);
        _fixture.RoundRepository.Setup(x => x.GetById(id))
            .Returns((Round)null!);

        // Act
        Action action = () => _service.GetById(id);

        // Assert
        action.Should().Throw<NotFoundException>()
            .WithMessage($"RoundId '{id}' was not found");
    }

    [Fact]
    public void RoundService_GetById_IdExists_Good()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();
        var expected = _fixture.AutoFixture.Create<Round>();

        _fixture.IdValidator.ReturnsAsValid(id, _idName);
        _fixture.RoundRepository.Setup(x => x.GetById(id))
            .Returns(expected);

        // Act
        var actual = _service.GetById(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
