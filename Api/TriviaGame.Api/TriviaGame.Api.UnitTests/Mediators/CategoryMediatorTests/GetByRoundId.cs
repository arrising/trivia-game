using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models;
using TriviaGame.Api.UnitTests.TestHelpers;

namespace TriviaGame.Api.UnitTests.Mediators.CategoryMediatorTests;

public class GetByRoundId : IClassFixture<CategoryMediatorFixture>
{
    private readonly CategoryMediatorFixture _fixture;
    private readonly string _idName = "roundId";
    private readonly ICategoryMediator _mediator;

    public GetByRoundId(CategoryMediatorFixture fixture)
    {
        _fixture = fixture;
        _mediator = _fixture.CreateInstance();
    }

    [Fact]
    public void CategoryMediator_GetByRoundId_HasValidationError_Throws()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.IdValidator.ReturnsWithException(id, _idName);

        // Act
        Action action = () => _mediator.GetByRoundId(id);

        // Assert
        action.Should().Throw<TestException>();
    }

    public static TheoryData<IEnumerable<Category>?> MissingCategoriesData = new()
    {
        null,
        Enumerable.Empty<Category>()
    };

    [Theory]
    [MemberData(nameof(MissingCategoriesData))]
    public void CategoryMediator_GetByRoundId_IdDoesNotExist_Throws(IEnumerable<Category>? data)
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.IdValidator.ReturnsAsValid(id, _idName);
        _fixture.CategoryRepository.Setup(x => x.GetByParentId(id))
            .Returns(data);

        // Act
        Action action = () => _mediator.GetByRoundId(id);

        // Assert
        action.Should().Throw<NotFoundException>()
            .WithMessage($"Categories for roundId '{id}' were not found");
    }

    [Fact]
    public void CategoryMediator_GetByRoundId_IdExists_Good()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();
        var expected = _fixture.AutoFixture.CreateMany<Category>();

        _fixture.IdValidator.ReturnsAsValid(id, _idName);
        _fixture.CategoryRepository.Setup(x => x.GetByParentId(id))
            .Returns(expected);

        // Act
        var actual = _mediator.GetByRoundId(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
