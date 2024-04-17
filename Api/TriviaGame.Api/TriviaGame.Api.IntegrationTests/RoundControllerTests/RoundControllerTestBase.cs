namespace TriviaGame.Api.IntegrationTests.RoundControllerTests;

// Required to assure shard ApplicationFixture is only created once
[Collection("IntegrationTests")]
public class RoundControllerTestBase : IntegrationTestBase
{
    public RoundControllerTestBase(ApplicationFixture fixture) : base(fixture) { }
    public override string TestUrl => "api/rounds";
}
