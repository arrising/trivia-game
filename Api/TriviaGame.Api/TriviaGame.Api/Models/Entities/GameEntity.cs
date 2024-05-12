using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Requests;

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

    public GameEntity(GameEntity game, UpdateGameRequest update)
    {
        Id = game.Id;
        Name = update.Name ?? game.Name;
        ValueSymbol = update.ValueSymbol ?? game.ValueSymbol;
        Rounds = game.Rounds ?? new List<RoundEntity>();
    }

    [Key]
    public Guid Id { get; init; } = Guid.Empty;

    public string Name { get; init; }
    public string ValueSymbol { get; init; }

    public IEnumerable<RoundEntity> Rounds { get; init; } = new List<RoundEntity>();
}
