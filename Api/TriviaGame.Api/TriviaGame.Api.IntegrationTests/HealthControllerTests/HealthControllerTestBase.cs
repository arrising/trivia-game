namespace TriviaGame.Api.IntegrationTests.HealthControllerTests;

public class HealthControllerTestBase : IntegrationTestBase
{
    public HealthControllerTestBase(ApplicationFixture fixture) : base(fixture) { }

    public override string TestUrl => "api/health";

}
