using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Mediators;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.UnitTests.Mediators.GameMediatorTests;

public class GameMediatorFixture : BaseTestFixture<IGameMediator>
{
    public Mock<IRepository<Game>> GameRepository;

    public GameMediatorFixture()
    {
        GameRepository = Repository.Create<IRepository<Game>>();
    }

    public override IGameMediator CreateInstance() => 
        new GameMediator(GameRepository.Object);
}
