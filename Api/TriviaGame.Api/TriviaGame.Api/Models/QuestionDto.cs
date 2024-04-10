namespace TriviaGame.Api.Models;

public class QuestionDto
{
    public QuestionDto() { }

    public QuestionDto(Question question)
    {
        Id = question.Id;
        Value = question.Value;
        Ask = question.Ask;
        Answer = question.Answer;
        Note = question.Note;
        Alternatives = question.Alternatives?.Any() == true ? question.Alternatives.Split('|') : null;
    }

    public string Id { get; set; }
    public int Value { get; set; }
    public string Ask { get; set; }
    public string Answer { get; set; }
    public string? Note { get; set; }
    public IEnumerable<string>? Alternatives { get; set; }
}
