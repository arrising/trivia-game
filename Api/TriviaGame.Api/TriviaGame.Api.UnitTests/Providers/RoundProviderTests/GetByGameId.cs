using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.UnitTests.Providers.RoundProviderTests;

public class GetByGameId : IClassFixture<RoundProviderFixture>
{
    public static TheoryData<IEnumerable<RoundEntity>?> MissingRoundsData = new()
    {
        null,
        Enumerable.Empty<RoundEntity>()
    };

    private readonly RoundProviderFixture _fixture;
    private readonly IRoundProvider _provider;

    public GetByGameId(RoundProviderFixture fixture)
    {
        _fixture = fixture;
        _provider = _fixture.CreateInstance();
    }

    [Theory]
    [MemberData(nameof(MissingRoundsData))]
    public void RoundProvider_GetByGameId_IdDoesNotExist_Throws(IEnumerable<RoundEntity>? data)
    {
        // Arrange
        var guid = Guid.NewGuid();
        var id = guid.ToString();

        _fixture.RoundRepository.Setup(x => x.GetByParentId(guid))
            .Returns(data);

        // Act
        Action action = () => _provider.GetByGameId(id);

        // Assert
        action.Should().Throw<NotFoundException>()
            .WithMessage($"Rounds for gameId '{id}' were not found");
    }

    [Fact]
    public void RoundProvider_GetByGameId_IdExists_Good()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var id = guid.ToString();
        var entities = _fixture.AutoFixture.CreateMany<RoundEntity>();
        var expected = entities.Select(entity => new RoundDto(entity));

        _fixture.RoundRepository.Setup(x => x.GetByParentId(guid))
            .Returns(entities);

        // Act
        var actual = _provider.GetByGameId(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
