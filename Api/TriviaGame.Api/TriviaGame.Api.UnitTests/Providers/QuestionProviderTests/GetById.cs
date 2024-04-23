using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.UnitTests.Providers.QuestionProviderTests;

public class GetById : IClassFixture<QuestionProviderFixture>
{
    private readonly QuestionProviderFixture _fixture;
    private readonly IQuestionProvider _provider;

    public GetById(QuestionProviderFixture fixture)
    {
        _fixture = fixture;
        _provider = _fixture.CreateInstance();
    }

    [Fact]
    public void QuestionProvider_GetById_IdDoesNotExist_Throws()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var id = guid.ToString();

        _fixture.QuestionRepository.Setup(x => x.GetById(guid))
            .Returns((QuestionEntity)null!);

        // Act
        Action action = () => _provider.GetById(id);

        // Assert
        action.Should().Throw<NotFoundException>()
            .WithMessage($"QuestionId '{id}' was not found");
    }

    [Fact]
    public void QuestionProvider_GetById_IdExists_Good()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var id = guid.ToString();
        var entity = _fixture.AutoFixture.Create<QuestionEntity>();
        var expected = new QuestionDto(entity);

        _fixture.QuestionRepository.Setup(x => x.GetById(guid))
            .Returns(entity);

        // Act
        var actual = _provider.GetById(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
