using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models;
using TriviaGame.Api.UnitTests.TestHelpers;

namespace TriviaGame.Api.UnitTests.Mediators.CategoryMediatorTests;

public class GetById : IClassFixture<CategoryMediatorFixture>
{
    private readonly CategoryMediatorFixture _fixture;
    private readonly string _idName = "categoryId";
    private readonly ICategoryMediator _mediator;

    public GetById(CategoryMediatorFixture fixture)
    {
        _fixture = fixture;
        _mediator = _fixture.CreateInstance();
    }

    [Fact]
    public void CategoryMediator_GetById_HasValidationError_Throws()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.IdValidator.ReturnsWithException(id, _idName);

        // Act
        Action action = () => _mediator.GetById(id);

        // Assert
        action.Should().Throw<TestException>();
    }

    [Fact]
    public void CategoryMediator_GetById_IdDoesNotExist_Throws()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.IdValidator.ReturnsAsValid(id, _idName);
        _fixture.CategoryRepository.Setup(x => x.GetById(id))
            .Returns((Category)null!);

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
        var expected = _fixture.AutoFixture.Create<Category>();

        _fixture.IdValidator.ReturnsAsValid(id, _idName);
        _fixture.CategoryRepository.Setup(x => x.GetById(id))
            .Returns(expected);

        // Act
        var actual = _mediator.GetById(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
