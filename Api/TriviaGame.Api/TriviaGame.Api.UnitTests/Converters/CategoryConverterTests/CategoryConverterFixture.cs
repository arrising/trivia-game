using TriviaGame.Api.Converters;
using TriviaGame.Api.Converters.Interfaces;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Converters.CategoryConverterTests;

public class CategoryConverterFixture : BaseTestFixture<CategoryConverter>
{
    public Mock<IConverter<QuestionEntity, QuestionPointerDto>> PointerConverter;

    public CategoryConverterFixture()
    {
        PointerConverter = Repository.Create<IConverter<QuestionEntity, QuestionPointerDto>>();
    }

    public override CategoryConverter CreateInstance() => new(PointerConverter.Object);
}
