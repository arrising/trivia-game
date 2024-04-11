using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Mediators;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.UnitTests.Mediators.RoundMediatorTests;

public class RoundMediatorFixture : BaseTestFixture<IRoundMediator>
{
    public Mock<IRepository<Round>> RoundRepository;

    public RoundMediatorFixture()
    {
        RoundRepository = Repository.Create<IRepository<Round>>();
    }

    public override IRoundMediator CreateInstance() =>
        new RoundMediator(RoundRepository.Object);
}
