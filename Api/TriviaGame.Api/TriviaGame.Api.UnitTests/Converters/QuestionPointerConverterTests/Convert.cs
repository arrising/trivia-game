using TriviaGame.Api.Converters;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Converters.QuestionPointerConverterTests;

public class Convert : IClassFixture<QuestionPointerConverterFixture>
{
    private readonly QuestionPointerConverter _converter;
    private readonly QuestionPointerConverterFixture _fixture;

    public Convert(QuestionPointerConverterFixture fixture)
    {
        _fixture = fixture;
        _converter = fixture.CreateInstance();
    }

    [Fact]
    public void QuestionPointerConverter_Covert_HasValue_Good()
    {
        var value = _fixture.AutoFixture.Create<QuestionEntity>();
        var expected = new QuestionPointerDto
        {
            Id = value.Id,
            Value = value.Value
        };

        var actual = _converter.Covert(value);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void QuestionPointerConverter_Covert_Null_ReturnsNull()
    {
        var actual = _converter.Covert(null);

        actual.Should().BeNull();
    }
}
