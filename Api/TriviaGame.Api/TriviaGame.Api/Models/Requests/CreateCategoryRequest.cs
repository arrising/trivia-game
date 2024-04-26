using System.ComponentModel.DataAnnotations;

namespace TriviaGame.Api.Models.Requests;

public class CreateCategoryRequest
{
    [Required]
    public Guid RoundId { get; init; }

    [Required]
    public string RoundName { get; init; }

    [Range(1, 10)]
    public int CategoryNumber { get; init; }

    [Range(1, 10)]
    public int QuestionsPerCategory { get; init; }

    [Range(1, 10)]
    public int QuestionBaseValue { get; init; }
}
