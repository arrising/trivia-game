using TriviaGame.Api.Factories;
using TriviaGame.Api.Factories.Interfaces;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Models.Requests;

namespace TriviaGame.Api.UnitTests.Factories.GameFactoryTests;

public class GameFactoryFixture : BaseTestFixture<GameFactory>
{
    public readonly Mock<IFactory<CreateRoundRequest, RoundEntity>> RoundFactory;

    public GameFactoryFixture()
    {
        RoundFactory = Repository.Create<IFactory<CreateRoundRequest, RoundEntity>>();
    }

    public override GameFactory CreateInstance() => new(RoundFactory.Object);
}
