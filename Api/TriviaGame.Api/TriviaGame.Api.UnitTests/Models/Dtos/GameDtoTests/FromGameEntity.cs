using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Models.Dtos.GameDtoTests;

public class FromGameEntity : IClassFixture<ModelsTestFixture>
{
    private readonly ModelsTestFixture _fixture;

    public FromGameEntity(ModelsTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void GameDto_From_GameEntity_HasValue_Good()
    {
        var value = _fixture.AutoFixture.Create<GameEntity>();
        var expected = new GameDto
        {
            Id = value.Id,
            Name = value.Name,
            ValueSymbol = value.ValueSymbol,
            RoundIds = value.Rounds.Select(x => x.Id)
        };

        var actual = new GameDto(value);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void GameDto_From_GameEntity_HasValueWithoutRounds_Good()
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

        var actual = new GameDto(value);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void GameDto_From_GameEntity_Null_Throws()
    {
        var action = () => new GameDto(null);

        action.Should().ThrowExactly<ConversionNullException>()
            .WithMessage("Can not create new GameDto from null (Parameter 'game')");
    }
}
