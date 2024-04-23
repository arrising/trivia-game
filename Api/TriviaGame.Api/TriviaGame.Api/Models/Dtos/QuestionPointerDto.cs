using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Models.Dtos;

public class QuestionPointerDto
{
    public QuestionPointerDto() { }

    public QuestionPointerDto(QuestionEntity question)
    {
        if (question == null)
        {
            throw new ConversionNullException(GetType(), nameof(question));
        }
        Id = question.Id.ToString();
        Value = question.Value;
    }

    public string Id { get; set; } = null!;
    public int Value { get; set; }
}
