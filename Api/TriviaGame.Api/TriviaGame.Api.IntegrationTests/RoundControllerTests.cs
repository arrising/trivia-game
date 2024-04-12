using TriviaGame.Api.IntegrationTests.TestHelpers;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.IntegrationTests;

// Required to assure shard ApplicationFixture is only created once
[Collection("IntegrationTests")]
public class RoundControllerTests : IClassFixture<ApplicationFixture>
{
    private readonly ApplicationFixture _fixture;
    private readonly string _testUrl = "api/rounds";

    public RoundControllerTests(ApplicationFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GetRoundById_Exists_Returns_Ok()
    {
        // Arrange
        var url = $"{_testUrl}/{TestIds.Game1_Round1}";
        var expected = new RoundDto
        {
            Id = TestIds.Game1_Round1,
            Type = "Single",
            CategoryIds = new List<string>
            {
                TestIds.Game1_Round1_Cat1,
                TestIds.Game1_Round1_Cat2,
                TestIds.Game1_Round1_Cat3,
                TestIds.Game1_Round1_Cat4,
                TestIds.Game1_Round1_Cat5
            }
        };

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<RoundDto>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetRoundById_DoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{_testUrl}/{Guid.NewGuid()}";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetRoundById_IdIsNotGUID_Returns_BadRequest()
    {
        // Arrange
        var url = $"{_testUrl}/Not_A_Real_Id";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetRoundsByGameId_Exists_Returns_Ok()
    {
        // Arrange
        var url = $"{_testUrl}/byGameId/{TestIds.Game1}";
        var expected = new List<RoundDto>
        {
            new()
            {
                Id = TestIds.Game1_Round1,
                Type = "Single",
                CategoryIds = new List<string>
                {
                    TestIds.Game1_Round1_Cat1,
                    TestIds.Game1_Round1_Cat2,
                    TestIds.Game1_Round1_Cat3,
                    TestIds.Game1_Round1_Cat4,
                    TestIds.Game1_Round1_Cat5
                }
            },
            new()
            {
                Id = TestIds.Game1_Round2,
                Type = "Double",
                CategoryIds = new List<string>
                {
                    TestIds.Game1_Round2_Cat1,
                    TestIds.Game1_Round2_Cat2,
                    TestIds.Game1_Round2_Cat3,
                    TestIds.Game1_Round2_Cat4,
                    TestIds.Game1_Round2_Cat5
                }
            }
        };
            
        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<IEnumerable<RoundDto>>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetRoundsByGameId_DoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{_testUrl}/ByGameId/{Guid.NewGuid()}";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetRoundsByGameId_IdIsNotGUID_Returns_BadRequest()
    {
        // Arrange
        var url = $"{_testUrl}/ByGameId/Not_A_Real_Id";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }
}
