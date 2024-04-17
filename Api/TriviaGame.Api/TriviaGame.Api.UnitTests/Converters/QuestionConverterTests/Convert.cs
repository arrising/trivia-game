using TriviaGame.Api.Converters;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Converters.QuestionConverterTests;

public class Convert : IClassFixture<QuestionConverterFixture>
{
    private readonly QuestionConverter _converter;
    private readonly QuestionConverterFixture _fixture;

    public Convert(QuestionConverterFixture fixture)
    {
        _fixture = fixture;
        _converter = _fixture.CreateInstance();
    }

    [Fact]
    public void QuestionConverter_Convert_HasValue_Good()
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
        var actual = _converter.Covert(value);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void QuestionConverter_Convert_HasValueMissingAlternatives_Good()
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
        var actual = _converter.Covert(value);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void QuestionConverter_Convert_Null_ReturnsNull()
    {
        var actual = _converter.Covert(null);

        actual.Should().BeNull();
    }
}
