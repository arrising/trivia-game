using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Models.Dtos.QuestionDtoTests;

public class FromQuestionEntity : IClassFixture<ModelsTestFixture>
{
    private readonly ModelsTestFixture _fixture;

    public FromQuestionEntity(ModelsTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void QuestionDto_From_QuestionEntity_HasValue_Good()
    {
        var value = _fixture.AutoFixture.Create<QuestionEntity>();
        var expected = new QuestionDto
        {
            Id = value.Id.ToString(),
            Value = value.Value,
            Ask = value.Ask,
            Answer = value.Answer,
            Note = value.Note,
            Alternatives = value.Alternatives.Split('|')
        };

        var actual = new QuestionDto(value);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void QuestionDto_From_QuestionEntity_HasValueMissingAlternatives_Good()
    {
        var value = _fixture.AutoFixture.Build<QuestionEntity>()
            .Without(x => x.Alternatives)
            .Create();
        var expected = new QuestionDto
        {
            Id = value.Id.ToString(),
            Value = value.Value,
            Ask = value.Ask,
            Answer = value.Answer,
            Note = value.Note,
            Alternatives = null
        };

        var actual = new QuestionDto(value);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void QuestionDto_From_QuestionEntity_Null_Throws()
    {
        var action = () => new QuestionDto(null);

        action.Should().ThrowExactly<ConversionNullException>()
            .WithMessage("Can not create new QuestionDto from null (Parameter 'question')");
    }
}
