using System.Linq;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.UnitTests.Providers.QuestionProviderTests;

public class GetByRoundId : IClassFixture<QuestionProviderFixture>
{
    private readonly QuestionProviderFixture _fixture;
    private readonly IQuestionProvider _provider;

    public static TheoryData<IEnumerable<QuestionEntity>?> MissingCategoriesData = new()
    {
        null,
        Enumerable.Empty<QuestionEntity>()
    };

    public GetByRoundId(QuestionProviderFixture fixture)
    {
        _fixture = fixture;
        _provider = _fixture.CreateInstance();
    }

    [Theory]
    [MemberData(nameof(MissingCategoriesData))]
    public void QuestionProvider_GetByCategoryId_IdDoesNotExist_Throws(IEnumerable<QuestionEntity>? data)
    {
        // Arrange
        var guid = Guid.NewGuid();
        var id = guid.ToString();

        _fixture.QuestionRepository.Setup(x => x.GetByParentId(guid))
            .Returns(data);

        // Act
        Action action = () => _provider.GetByCategoryId(id);

        // Assert
        action.Should().Throw<NotFoundException>()
            .WithMessage($"Questions for categoryId '{id}' were not found");
    }

    [Fact]
    public void QuestionProvider_GetByCategoryId_IdExists_Good()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var id = guid.ToString();
        var entities = _fixture.AutoFixture.CreateMany<QuestionEntity>();
        var expected = entities.Select(entity => new QuestionDto(entity));

        _fixture.QuestionRepository.Setup(x => x.GetByParentId(guid))
            .Returns(entities);

        // Act
        var actual = _provider.GetByCategoryId(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
