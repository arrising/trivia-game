using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Models.Dtos;

public class CategoryDto
{
    public CategoryDto() { }

    public CategoryDto(CategoryEntity category)
    {
        if (category == null)
        {
            throw new ConversionNullException(nameof(category));
        }

        Id = category.Id;
        Name = category.Name;
        Note = category.Note;
        Questions = category.Questions?.Select(x => new QuestionPointerDto(x)) ??
                    Enumerable.Empty<QuestionPointerDto>();
    }

    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Note { get; set; }
    public IEnumerable<QuestionPointerDto> Questions { get; set; } = Enumerable.Empty<QuestionPointerDto>();
}
