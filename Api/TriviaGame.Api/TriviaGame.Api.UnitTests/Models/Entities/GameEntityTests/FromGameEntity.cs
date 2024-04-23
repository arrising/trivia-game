using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Models.Entities.GameEntityTests;

public class FromGameEntity : IClassFixture<ModelsTestFixture>
{
    private readonly ModelsTestFixture _fixture;

    public FromGameEntity(ModelsTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void GameEntity_From_GameEntity_HasValue_Good()
    {
        var value = _fixture.AutoFixture.Create<GameEntity>();
        var expected = new GameEntity
        {
            Id = value.Id,
            Name = value.Name,
            ValueSymbol = value.ValueSymbol,
            Rounds = value.Rounds
        };

        var actual = new GameEntity(value);

        actual.Should().BeEquivalentTo(expected).And.NotBeSameAs(value);
    }

    [Fact]
    public void GameEntity_From_GameEntity_HasValueMissingRounds_Good()
    {
        var value = _fixture.AutoFixture.Build<GameEntity>()
            .Without(x => x.Rounds)
            .Create();
        var expected = new GameEntity
        {
            Id = value.Id,
            Name = value.Name,
            ValueSymbol = value.ValueSymbol,
            Rounds = new List<RoundEntity>()
        };

        var actual = new GameEntity(value);

        actual.Should().BeEquivalentTo(expected).And.NotBeSameAs(value);
    }

    [Fact]
    public void GameEntity_From_GameEntity_Null_Throws()
    {
        var action = () => new GameEntity(null);

        action.Should().ThrowExactly<ConversionNullException>()
            .WithMessage("Can not create new GameEntity from null (Parameter 'game')");
    }
}
