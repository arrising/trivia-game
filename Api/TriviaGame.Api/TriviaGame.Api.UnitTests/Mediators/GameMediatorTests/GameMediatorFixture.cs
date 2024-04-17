using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Mediators;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Mediators.GameMediatorTests;

public class GameMediatorFixture : BaseTestFixture<IGameMediator>
{
    public Mock<IRepository<GameEntity>> GameRepository;

    public GameMediatorFixture()
    {
        GameRepository = Repository.Create<IRepository<GameEntity>>();
    }

    public override IGameMediator CreateInstance() => 
        new GameMediator(GameRepository.Object);
}
