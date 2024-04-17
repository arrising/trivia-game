using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.UnitTests.Providers.CategoryProviderTests;

public class GetById : IClassFixture<CategoryProviderFixture>
{
    private readonly CategoryProviderFixture _fixture;
    private readonly ICategoryProvider _provider;

    public GetById(CategoryProviderFixture fixture)
    {
        _fixture = fixture;
        _provider = _fixture.CreateInstance();
    }

    [Fact]
    public void CategoryProvider_GetById_IdDoesNotExist_Throws()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.CategoryRepository.Setup(x => x.GetById(id))
            .Returns((CategoryEntity)null!);

        // Act
        Action action = () => _provider.GetById(id);

        // Assert
        action.Should().Throw<NotFoundException>()
            .WithMessage($"CategoryId '{id}' was not found");
    }

    [Fact]
    public void CategoryMediator_GetById_IdExists_Good()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();
        var expected = _fixture.AutoFixture.Create<CategoryEntity>();

        _fixture.CategoryRepository.Setup(x => x.GetById(id))
            .Returns(expected);

        // Act
        var actual = _provider.GetById(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
