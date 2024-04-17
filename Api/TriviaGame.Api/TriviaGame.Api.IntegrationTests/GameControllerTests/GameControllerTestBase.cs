namespace TriviaGame.Api.IntegrationTests.GameControllerTests;

public class GameControllerTestBase : IntegrationTestBase
{
    public override string TestUrl => "api/games";
    public GameControllerTestBase(ApplicationFixture fixture) : base(fixture) { }
}
