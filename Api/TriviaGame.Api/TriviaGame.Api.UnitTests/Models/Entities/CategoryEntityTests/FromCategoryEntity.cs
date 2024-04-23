using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Models.Entities.CategoryEntityTests;

public class FromCategoryEntity : IClassFixture<ModelsTestFixture>
{
    private readonly ModelsTestFixture _fixture;

    public FromCategoryEntity(ModelsTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void CategoryEntity_From_CategoryEntity_HasValue_Good()
    {
        var value = _fixture.AutoFixture.Create<CategoryEntity>();
        var expected = new CategoryEntity
        {
            Id = value.Id,
            RoundId = value.RoundId,
            Name = value.Name,
            Note = value.Note,
            Questions = value.Questions,
            Round = value.Round
        };

        var actual = new CategoryEntity(value);

        actual.Should().BeEquivalentTo(expected).And.NotBeSameAs(value);
    }

    [Fact]
    public void CategoryEntity_From_CategoryEntity_HasValueMissingQuestions_Good()
    {
        var value = _fixture.AutoFixture.Build<CategoryEntity>()
            .Without(x => x.Questions)
            .Create();
        var expected = new CategoryEntity
        {
            Id = value.Id,
            RoundId = value.RoundId,
            Name = value.Name,
            Note = value.Note,
            Questions = new List<QuestionEntity>(),
            Round = value.Round
        };

        var actual = new CategoryEntity(value);

        actual.Should().BeEquivalentTo(expected).And.NotBeSameAs(value);
    }

    [Fact]
    public void CategoryEntity_From_CategoryEntity_Null_Throws()
    {
        var action = () => new CategoryEntity(null);

        action.Should().ThrowExactly<ConversionNullException>()
            .WithMessage("Can not create new CategoryEntity from null (Parameter 'category')");
    }
}
