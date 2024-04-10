using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models;
using TriviaGame.Api.UnitTests.TestHelpers;

namespace TriviaGame.Api.UnitTests.Mediators.QuestionMediatorTests;

public class GetByRoundId : IClassFixture<QuestionMediatorFixture>
{
    private readonly QuestionMediatorFixture _fixture;
    private readonly string _idName = "categoryId";
    private readonly IQuestionMediator _mediator;

    public static TheoryData<IEnumerable<Question>?> MissingCategoriesData = new()
    {
        null,
        Enumerable.Empty<Question>()
    };

    public GetByRoundId(QuestionMediatorFixture fixture)
    {
        _fixture = fixture;
        _mediator = _fixture.CreateInstance();
    }

    [Fact]
    public void QuestionMediator_GetByCategoryId_HasValidationError_Throws()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.IdValidator.ReturnsWithException(id, _idName);

        // Act
        Action action = () => _mediator.GetByCategoryId(id);

        // Assert
        action.Should().Throw<TestException>();
    }

    [Theory]
    [MemberData(nameof(MissingCategoriesData))]
    public void QuestionMediator_GetByCategoryId_IdDoesNotExist_Throws(IEnumerable<Question>? data)
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.IdValidator.ReturnsAsValid(id, _idName);
        _fixture.QuestionRepository.Setup(x => x.GetByParentId(id))
            .Returns(data);

        // Act
        Action action = () => _mediator.GetByCategoryId(id);

        // Assert
        action.Should().Throw<NotFoundException>()
            .WithMessage($"Questions for categoryId '{id}' were not found");
    }

    [Fact]
    public void QuestionMediator_GetByCategoryId_IdExists_Good()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();
        var expected = _fixture.AutoFixture.CreateMany<Question>();

        _fixture.IdValidator.ReturnsAsValid(id, _idName);
        _fixture.QuestionRepository.Setup(x => x.GetByParentId(id))
            .Returns(expected);

        // Act
        var actual = _mediator.GetByCategoryId(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
