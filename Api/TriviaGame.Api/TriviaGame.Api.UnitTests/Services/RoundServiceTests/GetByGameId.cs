using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models;
using TriviaGame.Api.Services.Interfaces;
using TriviaGame.Api.UnitTests.TestHelpers;

namespace TriviaGame.Api.UnitTests.Services.RoundServiceTests;

public class GetByGameId : IClassFixture<RoundServiceFixture>
{
    private readonly RoundServiceFixture _fixture;
    private readonly IRoundService _service;
    private readonly string _idName = "gameId";

    public GetByGameId(RoundServiceFixture fixture)
    {
        _fixture = fixture;
        _service = _fixture.CreateInstance();
    }

    [Fact]
    public void RoundService_GetByGameId_HasValidationError_Throws()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.IdValidator.ReturnsWithException(id, _idName);

        // Act
        Action action = () => _service.GetByGameId(id);

        // Assert
        action.Should().Throw<TestException>();
    }

    public static TheoryData<IEnumerable<Round>?> MissingRoundsData = new()
    {
        null,
        Enumerable.Empty<Round>()
    };

    [Theory]
    [MemberData(nameof(MissingRoundsData))]
    public void RoundService_GetByGameId_IdDoesNotExist_Throws(IEnumerable<Round>? data)
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.IdValidator.ReturnsAsValid(id, _idName);
        _fixture.RoundRepository.Setup(x => x.GetByParentId(id))
            .Returns(data);

        // Act
        Action action = () => _service.GetByGameId(id);

        // Assert
        action.Should().Throw<NotFoundException>()
            .WithMessage($"Rounds for gameId '{id}' were not found");
    }

    [Fact]
    public void RoundService_GetByGameId_IdExists_Good()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();
        var expected = _fixture.AutoFixture.CreateMany<Round>();

        _fixture.IdValidator.ReturnsAsValid(id, _idName);
        _fixture.RoundRepository.Setup(x => x.GetByParentId(id))
            .Returns(expected);

        // Act
        var actual = _service.GetByGameId(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
