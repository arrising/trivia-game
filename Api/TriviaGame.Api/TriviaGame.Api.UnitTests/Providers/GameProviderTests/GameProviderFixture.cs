using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Providers;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.UnitTests.Providers.GameProviderTests;

public class GameProviderFixture : BaseTestFixture<IGameProvider>
{
    public Mock<IRepository<GameEntity>> GameRepository;

    public GameProviderFixture()
    {
        GameRepository = Repository.Create<IRepository<GameEntity>>();
    }

    public override IGameProvider CreateInstance() => 
        new GameProvider(GameRepository.Object);
}
