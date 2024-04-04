using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models;
using TriviaGame.Api.Services;

namespace TriviaGame.Api.UnitTests.Services.GameServiceTests;

public class GameServiceFixture : BaseTestFixture<GameService>
{
    public Mock<IRepository<Game>> GameRepository;

    public GameServiceFixture()
    {
        GameRepository = Repository.Create<IRepository<Game>>();
    }

    public override GameService CreateInstance() => new(GameRepository.Object);
}
