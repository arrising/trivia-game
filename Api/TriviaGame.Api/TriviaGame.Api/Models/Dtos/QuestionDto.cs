using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Models.Dtos;

public class QuestionDto
{
    public QuestionDto() { }

    public QuestionDto(QuestionEntity question)
    {
        if (question == null)
        {
            throw new ConversionNullException(nameof(question));
        }

        Id = question.Id;
        Value = question.Value;
        Ask = question.Ask;
        Answer = question.Answer;
        Note = question.Note;
        Alternatives = question.Alternatives?.Any() == true ? question.Alternatives.Split('|') : null;
    }

    public string Id { get; set; } = null!;
    public int Value { get; set; }
    public string Ask { get; set; } = null!;
    public string Answer { get; set; } = null!;
    public string? Note { get; set; }
    public IEnumerable<string>? Alternatives { get; set; }
}
