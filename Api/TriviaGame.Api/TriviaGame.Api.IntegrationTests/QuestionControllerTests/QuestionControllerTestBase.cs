namespace TriviaGame.Api.IntegrationTests.QuestionControllerTests;

// Required to assure shard ApplicationFixture is only created once
[Collection("IntegrationTests")]
public class QuestionControllerTestBase : IntegrationTestBase
{
    public QuestionControllerTestBase(ApplicationFixture fixture) : base(fixture) { }
    public override string TestUrl => "api/questions";
}
