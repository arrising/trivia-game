using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Models.Dtos.QuestionPointerDtoTests;

public class FromQuestionEntity : IClassFixture<DtoTestFixture>
{
    private readonly DtoTestFixture _fixture;

    public FromQuestionEntity(DtoTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void QuestionPointerDto_From_QuestionEntity_HasValue_Good()
    {
        var value = _fixture.AutoFixture.Create<QuestionEntity>();
        var expected = new QuestionPointerDto
        {
            Id = value.Id,
            Value = value.Value
        };

        var actual = new QuestionPointerDto(value);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void QuestionPointerDto_From_QuestionEntity_HasValueMissingAlternates_Good()
    {
        var value = _fixture.AutoFixture.Build<QuestionEntity>()
            .Without(x => x.Alternatives)
            .Create();
        var expected = new QuestionPointerDto
        {
            Id = value.Id,
            Value = value.Value
        };

        var actual = new QuestionPointerDto(value);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void QuestionPointerDto_From_QuestionEntity_Null_Throws()
    {
        var action = () => new QuestionPointerDto(null);

        action.Should().ThrowExactly<ConversionNullException>()
            .WithMessage("Can not create new question from null (Parameter 'question')");
    }
}
