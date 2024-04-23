using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Models.Entities.QuestionEntityTests;

public class FromQuestionEntity : IClassFixture<ModelsTestFixture>
{
    private readonly ModelsTestFixture _fixture;

    public FromQuestionEntity(ModelsTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void QuestionEntity_From_QuestionEntity_HasValue_Good()
    {
        var value = _fixture.AutoFixture.Create<QuestionEntity>();
        var expected = new QuestionEntity
        {
            Id = value.Id,
            Value = value.Value,
            Ask = value.Ask,
            Answer = value.Answer,
            Alternatives = value.Alternatives,
            Note = value.Note,
            CategoryId = value.CategoryId,
            Category = value.Category
        };

        var actual = new QuestionEntity(value);

        actual.Should().BeEquivalentTo(expected).And.NotBeSameAs(value);
    }

    [Fact]
    public void QuestionEntity_From_QuestionEntity_HasValueMissingAlternatives_Good()
    {
        var value = _fixture.AutoFixture.Build<QuestionEntity>()
            .Without(x => x.Alternatives)
            .Create();
        var expected = new QuestionEntity
        {
            Id = value.Id,
            Value = value.Value,
            Ask = value.Ask,
            Answer = value.Answer,
            Note = value.Note,
            CategoryId = value.CategoryId,
            Category = value.Category
        };

        var actual = new QuestionEntity(value);

        actual.Should().BeEquivalentTo(expected).And.NotBeSameAs(value);
    }

    [Fact]
    public void QuestionEntity_From_QuestionEntity_HasValueMissingNote_Good()
    {
        var value = _fixture.AutoFixture.Build<QuestionEntity>()
            .Without(x => x.Note)
            .Create();
        var expected = new QuestionEntity
        {
            Id = value.Id,
            Value = value.Value,
            Ask = value.Ask,
            Answer = value.Answer,
            Alternatives = value.Alternatives,
            CategoryId = value.CategoryId,
            Category = value.Category
        };

        var actual = new QuestionEntity(value);

        actual.Should().BeEquivalentTo(expected).And.NotBeSameAs(value);
    }

    [Fact]
    public void QuestionEntity_From_QuestionEntity_Null_Throws()
    {
        var action = () => new QuestionEntity(null);

        action.Should().ThrowExactly<ConversionNullException>()
            .WithMessage("Can not create new QuestionEntity from null (Parameter 'question')");
    }
}
