using TriviaGame.Api.IntegrationTests.TestHelpers;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Requests;

namespace TriviaGame.Api.IntegrationTests.GameControllerTests;

/// <summary>
///     Using TestPriority 2 on all tests to assure these tests run after all read tests are completed
/// </summary>
public partial class GameControllerTests
{
    [Fact]
    [TestPriority(2)]
    public async Task UpdateGameById_IdExists_Good()
    {
        // Arrange
        var url = $"{TestUrl}/{TestIds.Game2}";
        var request = new UpdateGameRequest
        {
            Name = "UpdatedName",
            ValueSymbol = "%"
        };
        var expected = new GameDto
        {
            Id = TestIds.Game2,
            Name = "UpdatedName",
            ValueSymbol = "%",
            RoundIds = new[] { TestIds.Game2_Round1, TestIds.Game2_Round2 }
        };

        // Act
        var response = await Fixture.Client.PatchAsync(url, CreateContent(request));

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<GameDto>();

        result.Should().BeEquivalentTo(expected);

        // - Verify change occured
        var verifyResponse = await Fixture.Client.GetAsync(url);
        verifyResponse.Should().BeSuccessful();
        var verifyValue = await verifyResponse.DeserializeContentAsync<GameDto>();
        verifyValue.Should().BeEquivalentTo(expected);
    }

    [Fact]
    [TestPriority(2)]
    public async Task UpdateGameById_IdDoesNotExist_NotFound()
    {
        // Arrange
        var id = Guid.NewGuid();
        var url = $"{TestUrl}/{id}";
        var request = new UpdateGameRequest
        {
            Name = "UpdatedName",
            ValueSymbol = "%"
        };

        // Act
        var response = await Fixture.Client.PatchAsync(url, CreateContent(request));

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    [Fact]
    [TestPriority(2)]
    public async Task UpdateGameById_IdIsNotGUId_Returns_BadRequest()
    {
        // Arrange
        var url = $"{TestUrl}/Not_a_Real_Id";
        var request = new UpdateGameRequest
        {
            Name = "UpdatedName",
            ValueSymbol = "%"
        };

        // Act
        var response = await Fixture.Client.PatchAsync(url, CreateContent(request));

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }

    public static TheoryData<string, UpdateGameRequest> InvalidUpdateGameRequests { get; } =
        new()
        {
            { "No values to update", new UpdateGameRequest() },
            { "Empty Name", new UpdateGameRequest { Name = string.Empty } },
            { "Empty ValueSymbol", new UpdateGameRequest { ValueSymbol = string.Empty } },
            { "ValueSymbol too long", new UpdateGameRequest { ValueSymbol = "123456" } }
        };

    [Theory]
    [TestPriority(2)]
    [MemberData(nameof(InvalidUpdateGameRequests))]
    public async Task UpdateGameById_InvalidRequests_BadRequest(string description, UpdateGameRequest request)
    {
        // Arrange
        var url = $"{TestUrl}/{TestIds.Game2}";
        var expected = new GameDto
        {
            Id = TestIds.Game2,
            Name = "UpdatedName",
            ValueSymbol = "%",
            RoundIds = new[] { TestIds.Game2_Round1, TestIds.Game2_Round2 }
        };

        // Act
        var response = await Fixture.Client.PatchAsync(url, CreateContent(request));

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest, description);
    }
}
