using System.ComponentModel.DataAnnotations;
using TriviaGame.Api.Exceptions;

namespace TriviaGame.Api.Models.Entities;

public class QuestionEntity
{
    public QuestionEntity() {}

    public QuestionEntity(QuestionEntity question)
    {
        if (question == null)
        {
            throw new ConversionNullException(GetType(), nameof(question));
        }

        Id = question.Id;
        CategoryId = question.CategoryId;
        Category = question.Category;
        Value = question.Value;
        Ask = question.Ask;
        Answer = question.Answer;
        Note = question.Note;
        Alternatives = question.Alternatives;
    }

    [Key]
    public string Id { get; set; }
    public string CategoryId { get; set; }
    public CategoryEntity Category { get; set; }
    public int Value { get; set; }
    public string Ask { get; set; }
    public string Answer { get; set; }
    public string? Note { get; set; }
    public string? Alternatives { get; set; }
}
