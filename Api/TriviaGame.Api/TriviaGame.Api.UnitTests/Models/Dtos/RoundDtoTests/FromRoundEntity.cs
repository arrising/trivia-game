using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Models.Dtos.RoundDtoTests;

public class FromRoundEntity : IClassFixture<ModelsTestFixture>
{
    private readonly ModelsTestFixture _fixture;

    public FromRoundEntity(ModelsTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void RoundDto_From_RoundEntity_HasValue_Good()
    {
        var value = _fixture.AutoFixture.Create<RoundEntity>();
        var expected = new RoundDto
        {
            Id = value.Id.ToString(),
            Type = value.Type,
            CategoryIds = value.Categories.Select(x => x.Id.ToString())
        };

        var actual = new RoundDto(value);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void RoundDto_From_RoundEntity_HasValueMissingCategories_Good()
    {
        var value = _fixture.AutoFixture.Build<RoundEntity>()
            .Without(x => x.Categories)
            .Create();
        var expected = new RoundDto
        {
            Id = value.Id.ToString(),
            Type = value.Type,
            CategoryIds = Enumerable.Empty<string>()
        };

        var actual = new RoundDto(value);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void RoundDto_From_RoundEntity_Null_Throws()
    {
        var action = () => new RoundDto(null);

        action.Should().ThrowExactly<ConversionNullException>()
            .WithMessage("Can not create new RoundDto from null (Parameter 'round')");
    }
}
