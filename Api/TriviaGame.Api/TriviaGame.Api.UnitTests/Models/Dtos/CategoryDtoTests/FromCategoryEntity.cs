using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Models.Dtos.CategoryDtoTests;

public class FromCategoryEntity : IClassFixture<DtoTestFixture>
{
    private readonly DtoTestFixture _fixture;

    public FromCategoryEntity(DtoTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void CategoryDto_From_CategoryEntity_HasValue_Good()
    {
        var value = _fixture.AutoFixture.Create<CategoryEntity>();
        var expected = new CategoryDto
        {
            Id = value.Id,
            Name = value.Name,
            Note = value.Note,
            Questions = value.Questions.Select(question => new QuestionPointerDto
            {
                Id = question.Id,
                Value = question.Value
            })
        };

        var actual = new CategoryDto(value);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void CategoryDto_From_CategoryEntity_HasValueWithoutQuestions_Good()
    {
        var value = _fixture.AutoFixture.Build<CategoryEntity>()
            .Without(x => x.Questions)
            .Create();

        var expected = new CategoryDto
        {
            Id = value.Id,
            Name = value.Name,
            Note = value.Note,
            Questions = Enumerable.Empty<QuestionPointerDto>()
        };

        var actual = new CategoryDto(value);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void CategoryDto_From_CategoryEntity_Null_Throws()
    {
        var action = () => new CategoryDto(null);

        action.Should().ThrowExactly<ConversionNullException>()
            .WithMessage("Can not create new category from null (Parameter 'category')");
    }
}
