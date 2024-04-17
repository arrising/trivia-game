using TriviaGame.Api.Converters.Interfaces;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Converters;

public class CategoryConverter : IConverter<CategoryEntity, CategoryDto>
{
    private readonly IConverter<QuestionEntity, QuestionPointerDto> _pointerConverter;

    public CategoryConverter(IConverter<QuestionEntity, QuestionPointerDto> pointerConverter)
    {
        _pointerConverter = pointerConverter;
    }

    public CategoryDto Covert(CategoryEntity value)
    {
        return value != null
            ? new CategoryDto
            {
                Id = value.Id,
                Name = value.Name,
                Note = value.Note,
                Questions = value.Questions?.Select(x => _pointerConverter.Covert(x))
                            ?? Enumerable.Empty<QuestionPointerDto>()
            }
            : null;
    }
}
