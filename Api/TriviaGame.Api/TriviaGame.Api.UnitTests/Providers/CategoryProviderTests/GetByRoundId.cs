using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.UnitTests.Providers.CategoryProviderTests;

public class GetByRoundId : IClassFixture<CategoryProviderFixture>
{
    private readonly CategoryProviderFixture _fixture;
    private readonly ICategoryProvider _provider;

    public GetByRoundId(CategoryProviderFixture fixture)
    {
        _fixture = fixture;
        _provider = _fixture.CreateInstance();
    }

    public static TheoryData<IEnumerable<CategoryEntity>?> MissingCategoriesData = new()
    {
        null,
        Enumerable.Empty<CategoryEntity>()
    };

    [Theory]
    [MemberData(nameof(MissingCategoriesData))]
    public void CategoryProvider_GetByRoundId_IdDoesNotExist_Throws(IEnumerable<CategoryEntity>? data)
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.CategoryRepository.Setup(x => x.GetByParentId(id))
            .Returns(data);

        // Act
        Action action = () => _provider.GetByRoundId(id);

        // Assert
        action.Should().Throw<NotFoundException>()
            .WithMessage($"Categories for roundId '{id}' were not found");
    }

    [Fact]
    public void CategoryProvider_GetByRoundId_IdExists_Good()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();
        var expected = _fixture.AutoFixture.CreateMany<CategoryEntity>();

        _fixture.CategoryRepository.Setup(x => x.GetByParentId(id))
            .Returns(expected);

        // Act
        var actual = _provider.GetByRoundId(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
