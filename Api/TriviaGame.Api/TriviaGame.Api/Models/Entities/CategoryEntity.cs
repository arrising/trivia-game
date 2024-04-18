using System.ComponentModel.DataAnnotations;

namespace TriviaGame.Api.Models.Entities;

public class CategoryEntity
{
    [Key]
    public string Id { get; set; }
    public string RoundId { get; set; }
    public RoundEntity Round { get; set; }
    public string Name { get; set; }
    public string? Note { get; set; }
    public IEnumerable<QuestionEntity> Questions { get; set; }
}
