using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Models.Dtos.QuestionDtoTests;

public class FromQuestionEntity : IClassFixture<DtoTestFixture>
{
    private readonly DtoTestFixture _fixture;

    public FromQuestionEntity(DtoTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void QuestionDto_From_QuestionEntity_HasValue_Good()
    {
        var value = _fixture.AutoFixture.Create<QuestionEntity>();
        var expected = new QuestionDto
        {
            Id = value.Id,
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
            Id = value.Id,
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
            .WithMessage("Can not create new question from null (Parameter 'question')");
    }
}
