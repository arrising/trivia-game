using TriviaGame.Api.IntegrationTests.TestHelpers;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.IntegrationTests.RoundControllerTests;

public class GetRoundsByGameId : RoundControllerTestBase
{
    public GetRoundsByGameId(ApplicationFixture fixture) : base(fixture) { }


    [Fact]
    public async Task GetRoundsByGameId_Exists_Returns_Ok()
    {
        // Arrange
        var url = $"{TestUrl}/byGameId/{TestIds.Game1}";
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
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<IEnumerable<RoundDto>>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetRoundsByGameId_DoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{TestUrl}/ByGameId/{Guid.NewGuid()}";

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetRoundsByGameId_IdIsNotGUID_Returns_BadRequest()
    {
        // Arrange
        var url = $"{TestUrl}/ByGameId/Not_A_Real_Id";

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }
}
