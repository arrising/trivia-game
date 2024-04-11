using TriviaGame.Api.IntegrationTests.TestHelpers;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.IntegrationTests;

// Required to assure shard ApplicationFixture is only created once
[Collection("IntegrationTests")]
public class GameControllerTests : IClassFixture<ApplicationFixture>
{
    private readonly ApplicationFixture _fixture;
    private readonly string _testUrl = "api/games";

    public GameControllerTests(ApplicationFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GetAllGames_Returns_Ok()
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
    public async Task GetGameById_Exists_Returns_Ok()
    {
        // Arrange
        var url = $"{_testUrl}/{TestIds.Game1}";
        var expected = new Game
        {
            Id = TestIds.Game1,
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
    public async Task GetGameById_DoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{_testUrl}/{Guid.NewGuid()}";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetGameByIdIdIsNotGUId_Returns_BadRequest()
    {
        // Arrange
        var url = $"{_testUrl}/Not_A_Real_Id";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }
}
