using System.ComponentModel.DataAnnotations;
using TriviaGame.Api.Exceptions;

namespace TriviaGame.Api.Models.Entities;

public class GameEntity
{
    public GameEntity() { }

    public GameEntity(GameEntity game)
    {
        if (game == null)
        {
            throw new ConversionNullException(GetType(), nameof(game));
        }

        Id = game.Id;
        Name = game.Name;
        ValueSymbol = game.ValueSymbol;
        Rounds = game.Rounds ?? new List<RoundEntity>();
    }

    [Key]
    public Guid Id { get; init; } = Guid.Empty;

    public string Name { get; init; }
    public string ValueSymbol { get; init; }
    public IEnumerable<RoundEntity> Rounds { get; init; } = new List<RoundEntity>();
}
