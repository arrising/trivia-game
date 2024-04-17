using TriviaGame.Api.IntegrationTests.TestHelpers;
using TriviaGame.Api.Models.Dtos;

namespace TriviaGame.Api.IntegrationTests.RoundControllerTests;

public class GetRoundById : RoundControllerTestBase
{
    public GetRoundById(ApplicationFixture fixture) : base(fixture) { }

    [Fact]
    public async Task GetRoundById_Exists_Returns_Ok()
    {
        // Arrange
        var url = $"{TestUrl}/{TestIds.Game1_Round1}";
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
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<RoundDto>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetRoundById_DoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{TestUrl}/{Guid.NewGuid()}";

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetRoundById_IdIsNotGUID_Returns_BadRequest()
    {
        // Arrange
        var url = $"{TestUrl}/Not_A_Real_Id";

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }
}
