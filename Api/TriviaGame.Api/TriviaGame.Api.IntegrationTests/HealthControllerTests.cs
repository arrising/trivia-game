namespace TriviaGame.Api.IntegrationTests;

// Required to assure shard ApplicationFixture is only created once
[Collection("IntegrationTests")]
public class HealthControllerTests : IClassFixture<ApplicationFixture>
{
    private readonly ApplicationFixture _fixture;
    private readonly string _testUrl = "api/health";

    public HealthControllerTests(ApplicationFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GetHealth_Returns_Ok()
    {
        // Act
        var response = await _fixture.Client.GetAsync(_testUrl);

        // Assert
        response.Should().BeSuccessful();
    }
}
