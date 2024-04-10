namespace TriviaGame.Api.Models;

public class QuestionPointerDto
{
    public QuestionPointerDto() { }

    public QuestionPointerDto(Question question)
    {
        Id = question.Id;
        Value = question.Value;
    }

    public string Id { get; set; } = null!;
    public int Value { get; set; }
}
