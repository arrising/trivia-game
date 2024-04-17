using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Mediators.QuestionMediatorTests;

public class GetByRoundId : IClassFixture<QuestionMediatorFixture>
{
    private readonly QuestionMediatorFixture _fixture;
    private readonly IQuestionMediator _mediator;

    public static TheoryData<IEnumerable<QuestionEntity>?> MissingCategoriesData = new()
    {
        null,
        Enumerable.Empty<QuestionEntity>()
    };

    public GetByRoundId(QuestionMediatorFixture fixture)
    {
        _fixture = fixture;
        _mediator = _fixture.CreateInstance();
    }

    [Theory]
    [MemberData(nameof(MissingCategoriesData))]
    public void QuestionMediator_GetByCategoryId_IdDoesNotExist_Throws(IEnumerable<QuestionEntity>? data)
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

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
        var expected = _fixture.AutoFixture.CreateMany<QuestionEntity>();

        _fixture.QuestionRepository.Setup(x => x.GetByParentId(id))
            .Returns(expected);

        // Act
        var actual = _mediator.GetByCategoryId(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
