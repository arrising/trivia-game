using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TriviaGame.Api.Exceptions;

namespace TriviaGame.Api.Models.Entities;

[ExcludeFromCodeCoverage]
public class GameEntity
{
    public GameEntity() { }

    public GameEntity(GameEntity game)
    {
        if (game == null)
        {
            throw new ConversionNullException(nameof(game));
        }

        Id = game.Id;
        Name = game.Name;
        ValueSymbol = game.ValueSymbol;
        Rounds = game.Rounds ?? new List<RoundEntity>();
    }

    [Key]
    public string Id { get; init; }

    public string Name { get; init; }
    public string ValueSymbol { get; init; }
    public IEnumerable<RoundEntity> Rounds { get; init; } = new List<RoundEntity>();
}
