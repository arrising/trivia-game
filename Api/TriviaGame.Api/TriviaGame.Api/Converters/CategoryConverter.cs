using TriviaGame.Api.Converters.Interfaces;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Converters;

public class CategoryConverter : IConverter<CategoryEntity, CategoryDto>
{
    public CategoryDto Covert(CategoryEntity value) => value != null ? new CategoryDto(value) : null;
}
