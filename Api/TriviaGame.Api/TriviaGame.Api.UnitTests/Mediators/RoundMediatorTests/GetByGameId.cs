using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Mediators.RoundMediatorTests;

public class GetByGameId : IClassFixture<RoundMediatorFixture>
{
    private readonly RoundMediatorFixture _fixture;
    private readonly IRoundMediator _mediator;

    public GetByGameId(RoundMediatorFixture fixture)
    {
        _fixture = fixture;
        _mediator = _fixture.CreateInstance();
    }

    public static TheoryData<IEnumerable<RoundEntity>?> MissingRoundsData = new()
    {
        null,
        Enumerable.Empty<RoundEntity>()
    };

    [Theory]
    [MemberData(nameof(MissingRoundsData))]
    public void RoundMediator_GetByGameId_IdDoesNotExist_Throws(IEnumerable<RoundEntity>? data)
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.RoundRepository.Setup(x => x.GetByParentId(id))
            .Returns(data);

        // Act
        Action action = () => _mediator.GetByGameId(id);

        // Assert
        action.Should().Throw<NotFoundException>()
            .WithMessage($"Rounds for gameId '{id}' were not found");
    }

    [Fact]
    public void RoundMediator_GetByGameId_IdExists_Good()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();
        var expected = _fixture.AutoFixture.CreateMany<RoundEntity>();

        _fixture.RoundRepository.Setup(x => x.GetByParentId(id))
            .Returns(expected);

        // Act
        var actual = _mediator.GetByGameId(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
