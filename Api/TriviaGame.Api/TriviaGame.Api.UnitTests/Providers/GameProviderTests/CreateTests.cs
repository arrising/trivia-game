using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Models.Requests;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.UnitTests.Providers.GameProviderTests;

public class CreateTests : IClassFixture<GameProviderFixture>
{
    private readonly GameProviderFixture _fixture;
    private readonly IGameProvider _provider;

    public CreateTests(GameProviderFixture fixture)
    {
        _fixture = fixture;
        _provider = _fixture.CreateInstance();
    }

    [Fact]
    public async Task GameProvider_Create_Good()
    {
        var request = _fixture.AutoFixture.Create<CreateGameRequest>();
        var entity = _fixture.AutoFixture.Create<GameEntity>();
        var saveResponse = _fixture.AutoFixture.Create<GameEntity>();
        var token = _fixture.AutoFixture.Create<CancellationToken>();
        var expected = new GameDto(saveResponse);

        _fixture.GameFactory.Setup(x => x.Create(request))
            .Returns(entity);
        _fixture.GameRepository.Setup(x => x.Add(entity, token))
            .ReturnsAsync(saveResponse);

        var actual = await _provider.Create(request, token);

        actual.Should().BeEquivalentTo(expected);
    }
}
