using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Factories.Interfaces;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Models.Requests;
using TriviaGame.Api.Providers;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.UnitTests.Providers.GameProviderTests;

public class GameProviderFixture : BaseTestFixture<IGameProvider>
{
    public Mock<IComplexEntityRepository<GameEntity>> ComplexEntityRepository;
    public Mock<IFactory<CreateGameRequest, GameEntity>> GameFactory;
    public Mock<IRepository<GameEntity>> GameRepository;

    public GameProviderFixture()
    {
        ComplexEntityRepository = Repository.Create<IComplexEntityRepository<GameEntity>>();
        GameFactory = Repository.Create<IFactory<CreateGameRequest, GameEntity>>();
        GameRepository = Repository.Create<IRepository<GameEntity>>();
    }

    public override IGameProvider CreateInstance() =>
        new GameProvider(
            GameFactory.Object,
            GameRepository.Object,
            ComplexEntityRepository.Object);
}
