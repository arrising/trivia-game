using TriviaGame.Api.Converters;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Converters.GameConverterTests;

public class Convert : IClassFixture<GameConverterFixture>
{
    private readonly GameConverter _converter;
    private readonly GameConverterFixture _fixture;

    public Convert(GameConverterFixture fixture)
    {
        _fixture = fixture;
        _converter = _fixture.CreateInstance();
    }

    [Fact]
    public void GameConverter_Convert_HasValue_Good()
    {
        var value = _fixture.AutoFixture.Create<GameEntity>();
        var expected = new GameDto
        {
            Id = value.Id,
            Name = value.Name,
            ValueSymbol = value.ValueSymbol,
            RoundIds = value.Rounds.Select(x => x.Id)
        };

        var actual = _converter.Covert(value);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void GameConverter_Convert_HasValueWithoutRounds_Good()
    {
        var value = _fixture.AutoFixture.Build<GameEntity>()
            .Without(x => x.Rounds)
            .Create();
        var expected = new GameDto
        {
            Id = value.Id,
            Name = value.Name,
            ValueSymbol = value.ValueSymbol,
            RoundIds = Enumerable.Empty<string>()
        };

        var actual = _converter.Covert(value);

        actual.Should().BeEquivalentTo(expected);
    }
}
