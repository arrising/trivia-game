using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Mediators.CategoryMediatorTests;

public class GetByRoundId : IClassFixture<CategoryMediatorFixture>
{
    private readonly CategoryMediatorFixture _fixture;
    private readonly ICategoryMediator _mediator;

    public GetByRoundId(CategoryMediatorFixture fixture)
    {
        _fixture = fixture;
        _mediator = _fixture.CreateInstance();
    }

    public static TheoryData<IEnumerable<CategoryEntity>?> MissingCategoriesData = new()
    {
        null,
        Enumerable.Empty<CategoryEntity>()
    };

    [Theory]
    [MemberData(nameof(MissingCategoriesData))]
    public void CategoryMediator_GetByRoundId_IdDoesNotExist_Throws(IEnumerable<CategoryEntity>? data)
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

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
        var expected = _fixture.AutoFixture.CreateMany<CategoryEntity>();

        _fixture.CategoryRepository.Setup(x => x.GetByParentId(id))
            .Returns(expected);

        // Act
        var actual = _mediator.GetByRoundId(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
