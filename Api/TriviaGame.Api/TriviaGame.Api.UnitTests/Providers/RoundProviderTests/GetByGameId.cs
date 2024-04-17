using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.UnitTests.Providers.RoundProviderTests;

public class GetByGameId : IClassFixture<RoundProviderFixture>
{
    private readonly RoundProviderFixture _fixture;
    private readonly IRoundProvider _provider;

    public GetByGameId(RoundProviderFixture fixture)
    {
        _fixture = fixture;
        _provider = _fixture.CreateInstance();
    }

    public static TheoryData<IEnumerable<RoundEntity>?> MissingRoundsData = new()
    {
        null,
        Enumerable.Empty<RoundEntity>()
    };

    [Theory]
    [MemberData(nameof(MissingRoundsData))]
    public void RoundProvider_GetByGameId_IdDoesNotExist_Throws(IEnumerable<RoundEntity>? data)
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.RoundRepository.Setup(x => x.GetByParentId(id))
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
        var id = _fixture.AutoFixture.Create<string>();
        var expected = _fixture.AutoFixture.CreateMany<RoundEntity>();

        _fixture.RoundRepository.Setup(x => x.GetByParentId(id))
            .Returns(expected);

        // Act
        var actual = _provider.GetByGameId(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
