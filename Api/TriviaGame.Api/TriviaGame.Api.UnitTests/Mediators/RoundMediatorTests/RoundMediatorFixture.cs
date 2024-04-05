using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Mediators;
using TriviaGame.Api.Models;
using TriviaGame.Api.Validators.Interfaces;

namespace TriviaGame.Api.UnitTests.Mediators.RoundMediatorTests;

public class RoundMediatorFixture : BaseTestFixture<RoundMediator>
{
    public Mock<IRepository<Round>> RoundRepository;
    public Mock<IIdValidator> IdValidator;

    public RoundMediatorFixture()
    {
        RoundRepository = Repository.Create<IRepository<Round>>();
        IdValidator = Repository.Create<IIdValidator>();
    }

    public override RoundMediator CreateInstance() => new(RoundRepository.Object, IdValidator.Object);
}
