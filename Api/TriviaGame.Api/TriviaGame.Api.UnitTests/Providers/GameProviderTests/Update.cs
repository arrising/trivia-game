using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Models.Requests;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.UnitTests.Providers.GameProviderTests;

public class Update : IClassFixture<GameProviderFixture>
{
    private readonly GameProviderFixture _fixture;
    private readonly IGameProvider _provider;

    public Update(GameProviderFixture fixture)
    {
        _fixture = fixture;
        _provider = _fixture.CreateInstance();
    }

    [Fact]
    public async Task GameProvider_Update_IdExists_Good()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var id = guid.ToString();
        var update = _fixture.AutoFixture.Create<UpdateGameRequest>();
        var entity = _fixture.AutoFixture.Create<GameEntity>();
        var updatedEntity = new GameEntity(entity, update);
        var expected = new GameDto(updatedEntity);

        _fixture.GameRepository.Setup(x => x.GetById(guid))
            .Returns(entity);
        _fixture.GameRepository.Setup(x => x.Update(It.Is<GameEntity>(e => e.IsEquivalentTo(updatedEntity))))
            .Returns(Task.CompletedTask);

        // Act
        var actual = await _provider.Update(id, update);

        //Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GameProvider_Update_IdDoesNotExist_Throws()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var id = guid.ToString();
        var update = _fixture.AutoFixture.Create<UpdateGameRequest>();
        _fixture.GameRepository.Setup(x => x.GetById(guid))
            .Returns((GameEntity)null);

        //Act
        var action = async () => await _provider.Update(id, update);

        // Assert
        await action.Should().ThrowExactlyAsync<NotFoundException>()
            .WithMessage($"GameId '{id}' was not found");
    }

    [Theory]
    [MemberData(nameof(TestData.InvalidIds), MemberType = typeof(TestData))]
    public async Task GameProvider_UpdateInvalidId_Throws(string? id)
    {
        // Arrange
        var update = _fixture.AutoFixture.Create<UpdateGameRequest>();

        //Act
        var action = async () => await _provider.Update(id, update);

        // Assert
        await action.Should().ThrowExactlyAsync<ArgumentException>()
            .WithMessage($"Invalid gameId \"{id}\"*")
            .WithParameterName("gameId");
    }
}
