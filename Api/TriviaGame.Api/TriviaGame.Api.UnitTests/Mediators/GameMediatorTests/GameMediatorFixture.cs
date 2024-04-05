using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Mediators;
using TriviaGame.Api.Models;
using TriviaGame.Api.Validators.Interfaces;

namespace TriviaGame.Api.UnitTests.Mediators.GameMediatorTests;

public class GameMediatorFixture : BaseTestFixture<GameMediator>
{
    public Mock<IRepository<Game>> GameRepository;
    public Mock<IIdValidator> IdValidator;

    public GameMediatorFixture()
    {
        GameRepository = Repository.Create<IRepository<Game>>();
        IdValidator = Repository.Create<IIdValidator>();
    }

    public override GameMediator CreateInstance() => new(GameRepository.Object, IdValidator.Object);
}
