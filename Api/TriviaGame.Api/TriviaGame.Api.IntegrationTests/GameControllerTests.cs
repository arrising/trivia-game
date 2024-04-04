using TriviaGame.Api.IntegrationTests.TestHelpers;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.IntegrationTests;

[Collection("IntegrationTests")]
public class GameControllerTests : IClassFixture<ApplicationFixture>
{
    private readonly ApplicationFixture _fixture;
    private readonly string _testUrl = "api/game";

    public GameControllerTests(ApplicationFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GameController_GetAllGames_Returns_Ok()
    {
        // Arrange
        var expected = new List<Game>
        {
            new()
            {
                Id = "d12adfa5-26b5-4a6b-bd65-2dd02768437f",
                Name = "Game One",
                ValueSymbol = "$"
            },
            new()
            {
                Id = "71807a01-8dc2-40b9-ac9c-6977c3371357",
                Name = "Game Two",
                ValueSymbol = "$"
            }
        };

        // Act
        var response = await _fixture.Client.GetAsync(_testUrl);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<IEnumerable<Game>>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GameController_GetGameById_GameExists_Ok()
    {
        // Arrange
        var url = $"{_testUrl}/d12adfa5-26b5-4a6b-bd65-2dd02768437f";
        var expected = new Game()
            {
                Id = "d12adfa5-26b5-4a6b-bd65-2dd02768437f",
                Name = "Game One",
                ValueSymbol = "$"
            };

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<Game>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GameController_GetGameById_GameDoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{_testUrl}/Not_A_Real_Id";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }
}
