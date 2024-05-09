namespace TriviaGame.Api.IntegrationTests.GameControllerTests;

// Using partial class to allow for tests to run in order.
// This is necessary as GetAllGames is affected by the create tests
public partial class GameControllerTests : IntegrationTestBase
{
    public GameControllerTests(ApplicationFixture fixture) : base(fixture) { }
    public override string TestUrl => "api/games";
}
