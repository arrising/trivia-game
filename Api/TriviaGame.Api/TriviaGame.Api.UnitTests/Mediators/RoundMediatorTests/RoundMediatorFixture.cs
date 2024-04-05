using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Mediators;
using TriviaGame.Api.Mediators.Interfaces;
using TriviaGame.Api.Models;
using TriviaGame.Api.Validators.Interfaces;

namespace TriviaGame.Api.UnitTests.Mediators.RoundMediatorTests;

public class RoundMediatorFixture : BaseTestFixture<IRoundMediator>
{
    public Mock<IRepository<Round>> RoundRepository;
    public Mock<IIdValidator> IdValidator;

    public RoundMediatorFixture()
    {
        RoundRepository = Repository.Create<IRepository<Round>>();
        IdValidator = Repository.Create<IIdValidator>();
    }

    public override IRoundMediator CreateInstance() =>
        new RoundMediator(RoundRepository.Object, IdValidator.Object);
}
