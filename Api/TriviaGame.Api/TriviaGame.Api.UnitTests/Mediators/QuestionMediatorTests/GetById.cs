using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Mediators.QuestionMediatorTests;

public class GetById : IClassFixture<QuestionMediatorFixture>
{
    private readonly QuestionMediatorFixture _fixture;
    private readonly IQuestionMediator _mediator;

    public GetById(QuestionMediatorFixture fixture)
    {
        _fixture = fixture;
        _mediator = _fixture.CreateInstance();
    }

    [Fact]
    public void QuestionMediator_GetById_IdDoesNotExist_Throws()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.QuestionRepository.Setup(x => x.GetById(id))
            .Returns((QuestionEntity)null!);

        // Act
        Action action = () => _mediator.GetById(id);

        // Assert
        action.Should().Throw<NotFoundException>()
            .WithMessage($"QuestionId '{id}' was not found");
    }

    [Fact]
    public void QuestionMediator_GetById_IdExists_Good()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();
        var expected = _fixture.AutoFixture.Create<QuestionEntity>();

        _fixture.QuestionRepository.Setup(x => x.GetById(id))
            .Returns(expected);

        // Act
        var actual = _mediator.GetById(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
