namespace TriviaGame.Api.IntegrationTests.HealthControllerTests;

public class GetHealth : HealthControllerTestBase
{
    public GetHealth(ApplicationFixture fixture) : base(fixture) { }


    [Fact]
    public async Task GetHealth_Returns_Ok()
    {
        // Act
        var response = await Fixture.Client.GetAsync(TestUrl);

        // Assert
        response.Should().BeSuccessful();
    }
}
