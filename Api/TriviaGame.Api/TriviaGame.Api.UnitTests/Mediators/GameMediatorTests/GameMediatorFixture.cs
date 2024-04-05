using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Mediators;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models;
using TriviaGame.Api.Validators.Interfaces;

namespace TriviaGame.Api.UnitTests.Mediators.GameMediatorTests;

public class GameMediatorFixture : BaseTestFixture<IGameMediator>
{
    public Mock<IRepository<Game>> GameRepository;
    public Mock<IIdValidator> IdValidator;

    public GameMediatorFixture()
    {
        GameRepository = Repository.Create<IRepository<Game>>();
        IdValidator = Repository.Create<IIdValidator>();
    }

    public override IGameMediator CreateInstance() => 
        new GameMediator(GameRepository.Object, IdValidator.Object);
}
