using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Models.Dtos;

public class QuestionPointerDto
{
    public QuestionPointerDto() { }

    public QuestionPointerDto(QuestionEntity question)
    {
        Id = question.Id;
        Value = question.Value;
    }

    public string Id { get; set; } = null!;
    public int Value { get; set; }
}
