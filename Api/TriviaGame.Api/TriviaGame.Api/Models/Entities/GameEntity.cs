using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TriviaGame.Api.Models.Entities;

[ExcludeFromCodeCoverage]
public class GameEntity
{
    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
    public string ValueSymbol { get; set; }
    public IEnumerable<RoundEntity> Rounds { get; set; } = new List<RoundEntity>();
}
