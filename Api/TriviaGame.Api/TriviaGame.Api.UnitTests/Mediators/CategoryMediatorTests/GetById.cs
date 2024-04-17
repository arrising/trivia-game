using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Mediators.CategoryMediatorTests;

public class GetById : IClassFixture<CategoryMediatorFixture>
{
    private readonly CategoryMediatorFixture _fixture;
    private readonly ICategoryMediator _mediator;

    public GetById(CategoryMediatorFixture fixture)
    {
        _fixture = fixture;
        _mediator = _fixture.CreateInstance();
    }

    [Fact]
    public void CategoryMediator_GetById_IdDoesNotExist_Throws()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.CategoryRepository.Setup(x => x.GetById(id))
            .Returns((CategoryEntity)null!);

        // Act
        Action action = () => _mediator.GetById(id);

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
        var actual = _mediator.GetById(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
