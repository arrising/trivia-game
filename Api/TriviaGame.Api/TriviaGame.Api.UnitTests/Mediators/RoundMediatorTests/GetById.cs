using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Mediators.RoundMediatorTests;

public class GetById : IClassFixture<RoundMediatorFixture>
{
    private readonly RoundMediatorFixture _fixture;
    private readonly IRoundMediator _mediator;

    public GetById(RoundMediatorFixture fixture)
    {
        _fixture = fixture;
        _mediator = _fixture.CreateInstance();
    }

    [Fact]
    public void RoundMediator_GetById_IdDoesNotExist_Throws()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.RoundRepository.Setup(x => x.GetById(id))
            .Returns((RoundEntity)null!);

        // Act
        Action action = () => _mediator.GetById(id);

        // Assert
        action.Should().Throw<NotFoundException>()
            .WithMessage($"RoundId '{id}' was not found");
    }

    [Fact]
    public void RoundMediator_GetById_IdExists_Good()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();
        var expected = _fixture.AutoFixture.Create<RoundEntity>();

        _fixture.RoundRepository.Setup(x => x.GetById(id))
            .Returns(expected);

        // Act
        var actual = _mediator.GetById(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
