using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Mediators;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests.Mediators.RoundMediatorTests;

public class RoundMediatorFixture : BaseTestFixture<IRoundMediator>
{
    public Mock<IRepository<RoundEntity>> RoundRepository;

    public RoundMediatorFixture()
    {
        RoundRepository = Repository.Create<IRepository<RoundEntity>>();
    }

    public override IRoundMediator CreateInstance() =>
        new RoundMediator(RoundRepository.Object);
}
