using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TriviaGame.Api.Exceptions;

namespace TriviaGame.Api.Models.Entities;

public class RoundEntity
{
    public RoundEntity() { }

    public RoundEntity(RoundEntity round)
    {
        if (round == null)
        {
            throw new ConversionNullException(GetType(), nameof(round));
        }

        Id = round.Id;
        GameId = round.GameId;
        Game = round.Game;
        Type = round.Type;
        Categories = round.Categories ?? new List<CategoryEntity>();
    }

    [Key]
    public Guid Id { get; init; } = Guid.Empty;

    public Guid GameId { get; init; } = Guid.Empty;

    [ForeignKey("GameId")]
    public GameEntity Game { get; init; }

    public string Type { get; init; }
    public IEnumerable<CategoryEntity> Categories { get; init; } = new List<CategoryEntity>();
}
