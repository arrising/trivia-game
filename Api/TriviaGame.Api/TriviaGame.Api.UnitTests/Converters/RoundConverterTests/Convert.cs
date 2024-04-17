using TriviaGame.Api.Converters;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Converters.RoundConverterTests;

public class Convert : IClassFixture<RoundConverterFixture>
{
    private readonly RoundConverter _converter;
    private readonly RoundConverterFixture _fixture;

    public Convert(RoundConverterFixture fixture)
    {
        _fixture = fixture;
        _converter = _fixture.CreateInstance();
    }

    [Fact]
    public void RoundConverter_Convert_HasValue_Good()
    {
        var value = _fixture.AutoFixture.Create<RoundEntity>();
        var expected = new RoundDto
        {
            Id = value.Id,
            Type = value.Type,
            CategoryIds = value.Categories.Select(x => x.Id)
        };

        var actual = _converter.Covert(value);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void RoundConverter_Convert_HasValueMissingCategories_Good()
    {
        var value = _fixture.AutoFixture.Build<RoundEntity>()
            .Without(x => x.Categories)
            .Create();
        var expected = new RoundDto
        {
            Id = value.Id,
            Type = value.Type,
            CategoryIds = Enumerable.Empty<string>()
        };

        var actual = _converter.Covert(value);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void RoundConverter_Convert_Null_ReturnsNull()
    {
        var actual = _converter.Covert(null);

        actual.Should().BeNull();
    }
}
