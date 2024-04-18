using System.ComponentModel.DataAnnotations;

namespace TriviaGame.Api.Models.Entities;

public class RoundEntity
{
    [Key]
    public string Id { get; set; }
    public string GameId { get; set; }
    public GameEntity Game { get; set; }
    public string Type { get; set; }
    public IEnumerable<CategoryEntity> Categories { get; set; }
}
