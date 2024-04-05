using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models;
using TriviaGame.Api.Services;
using TriviaGame.Api.Validators.Interfaces;

namespace TriviaGame.Api.UnitTests.Services.RoundServiceTests;

public class RoundServiceFixture : BaseTestFixture<RoundService>
{
    public Mock<IRepository<Round>> RoundRepository;
    public Mock<IIdValidator> IdValidator;

    public RoundServiceFixture()
    {
        RoundRepository = Repository.Create<IRepository<Round>>();
        IdValidator = Repository.Create<IIdValidator>();
    }

    public override RoundService CreateInstance() => new(RoundRepository.Object, IdValidator.Object);
}
