using TriviaGame.Api.Converters;

namespace TriviaGame.Api.UnitTests.Converters.NumberConverterTests;

public class Convert : IClassFixture<NumberConverterFixture>
{
    private readonly NumberConverter _converter;
    private readonly NumberConverterFixture _fixture;

    public Convert(NumberConverterFixture fixture)
    {
        _fixture = fixture;
        _converter = new NumberConverter();
    }

    [Theory]
    [InlineData(0, "Zero")]
    [InlineData(1, "One")]
    [InlineData(2, "Two")]
    [InlineData(3, "Three")]
    [InlineData(4, "Four")]
    [InlineData(5, "Five")]
    [InlineData(6, "Six")]
    [InlineData(7, "Seven")]
    [InlineData(8, "Eight")]
    [InlineData(9, "Nine")]
    [InlineData(10, "Ten")]
    [InlineData(11, "11")]
    [InlineData(12, "12")]
    [InlineData(20, "20")]
    [InlineData(50, "50")]
    [InlineData(100, "100")]
    public void NumberConverterFixture_Convert_Good(int value, string expected)
    {
        var actual = _converter.Convert(value);

        actual.Should().Be(expected);
    }
}
