using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.UnitTests.Providers.RoundProviderTests;

public class GetById : IClassFixture<RoundProviderFixture>
{
    private readonly RoundProviderFixture _fixture;
    private readonly IRoundProvider _provider;

    public GetById(RoundProviderFixture fixture)
    {
        _fixture = fixture;
        _provider = _fixture.CreateInstance();
    }

    [Fact]
    public void RoundProvider_GetById_IdDoesNotExist_Throws()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();

        _fixture.RoundRepository.Setup(x => x.GetById(id))
            .Returns((RoundEntity)null!);

        // Act
        Action action = () => _provider.GetById(id);

        // Assert
        action.Should().Throw<NotFoundException>()
            .WithMessage($"RoundId '{id}' was not found");
    }

    [Fact]
    public void RoundProvider_GetById_IdExists_Good()
    {
        // Arrange
        var id = _fixture.AutoFixture.Create<string>();
        var entity = _fixture.AutoFixture.Create<RoundEntity>();
        var expected = new RoundDto(entity);

        _fixture.RoundRepository.Setup(x => x.GetById(id))
            .Returns(entity);

        // Act
        var actual = _provider.GetById(id);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
