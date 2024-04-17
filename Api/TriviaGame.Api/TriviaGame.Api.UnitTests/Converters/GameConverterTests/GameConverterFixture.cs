using TriviaGame.Api.Converters;

namespace TriviaGame.Api.UnitTests.Converters.GameConverterTests;

public class GameConverterFixture : BaseTestFixture<GameConverter>
{
    public override GameConverter CreateInstance() => new();
}
