using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TriviaGame.Api.IntegrationTests;

public class HealthControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public HealthControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_Health()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("api/health");

        // Assert
        response.Should().BeSuccessful();
    }
}
