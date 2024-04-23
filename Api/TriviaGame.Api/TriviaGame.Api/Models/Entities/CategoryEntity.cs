using System.ComponentModel.DataAnnotations;
using TriviaGame.Api.Exceptions;

namespace TriviaGame.Api.Models.Entities;

public class CategoryEntity
{
    public CategoryEntity() { }

    public CategoryEntity(CategoryEntity category)
    {
        if (category == null)
        {
            throw new ConversionNullException(GetType(), nameof(category));
        }

        Id = category.Id;
        RoundId = category.RoundId;
        Round = category.Round;
        Name = category.Name;
        Note = category.Note;
        Questions = category.Questions ?? new List<QuestionEntity>();
    }

    [Key]
    public string Id { get; set; }

    public string RoundId { get; set; }
    public RoundEntity Round { get; set; }
    public string Name { get; set; }
    public string? Note { get; set; }
    public IEnumerable<QuestionEntity> Questions { get; set; } = new List<QuestionEntity>();
}
