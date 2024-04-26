using System.ComponentModel.DataAnnotations;

namespace TriviaGame.Api.Models.Requests;

public class CreateQuestionRequest
{
    [Required]
    public Guid CategoryId { get; init; }

    [Required]
    public string CategoryName { get; init; }

    [Range(1, 10)]
    public int QuestionNumber { get; init; }

    [Range(1, 10)]
    public int QuestionValue { get; init; }
}
