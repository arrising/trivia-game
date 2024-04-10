namespace TriviaGame.Api.Models;

public class CategoryDto
{
    public CategoryDto() { }

    public CategoryDto(Category category)
    {
        Id = category.Id;
        Name = category.Name;
        Note = category.Note;
        Questions = category.Questions.Select(x => new QuestionPointerDto(x));
    }

    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Note { get; set; }
    public IEnumerable<QuestionPointerDto> Questions { get; set; } = null!;
}
