using System.ComponentModel.DataAnnotations;

namespace TriviaGame.Api.Models;

public class Question
{
    [Key]
    public string Id { get; set; }

    public string CategoryId { get; set; }
    public int Value { get; set; }
    public string Ask { get; set; }
    public string Answer { get; set; }
    public string? Note { get; set; }
    public string? Alternatives { get; set; }
}
