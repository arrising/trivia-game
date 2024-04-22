using TriviaGame.Api.Converters;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Converters.CategoryConverterTests;

public class Convert : IClassFixture<CategoryConverterFixture>
{
    private readonly CategoryConverter _converter;
    private readonly CategoryConverterFixture _fixture;

    public Convert(CategoryConverterFixture fixture)
    {
        _fixture = fixture;
        _converter = fixture.CreateInstance();
    }

    [Fact]
    public void CategoryConverter_Covert_HasValue_Good()
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

        var actual = _converter.Covert(value);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void CategoryConverter_Covert_HasValueWithoutQuestions_Good()
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

        var actual = _converter.Covert(value);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void CategoryConverter_Covert_Null_ReturnsNull()
    {
        var actual = _converter.Covert(null);

        actual.Should().BeNull();
    }
}
