using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models;
using TriviaGame.Api.Services;
using TriviaGame.Api.Validators.Interfaces;

namespace TriviaGame.Api.UnitTests.Services.GameServiceTests;

public class GameServiceFixture : BaseTestFixture<GameService>
{
    public Mock<IRepository<Game>> GameRepository;
    public Mock<IIdValidator> IdValidator;

    public GameServiceFixture()
    {
        GameRepository = Repository.Create<IRepository<Game>>();
        IdValidator = Repository.Create<IIdValidator>();
    }

    public override GameService CreateInstance() => new(GameRepository.Object, IdValidator.Object);
}
