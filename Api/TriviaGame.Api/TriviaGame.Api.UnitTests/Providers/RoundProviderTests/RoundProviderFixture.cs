using TriviaGame.Api.Data.Interfaces;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Providers;
using TriviaGame.Api.Providers.Interfaces;

namespace TriviaGame.Api.UnitTests.Providers.RoundProviderTests;

public class RoundProviderFixture : BaseTestFixture<IRoundProvider>
{
    public Mock<IRepository<RoundEntity>> RoundRepository;

    public RoundProviderFixture()
    {
        RoundRepository = Repository.Create<IRepository<RoundEntity>>();
    }

    public override IRoundProvider CreateInstance() =>
        new RoundProvider(RoundRepository.Object);
}
