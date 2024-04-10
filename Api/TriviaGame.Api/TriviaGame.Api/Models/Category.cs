using System.ComponentModel.DataAnnotations;

namespace TriviaGame.Api.Models;

public class Category
{
    [Key]
    public string Id { get; set; }
    public string RoundId { get; set; }
    public string Name { get; set; }
    public string? Note { get; set; }
    public IEnumerable<Question> Questions { get; set; }
}
