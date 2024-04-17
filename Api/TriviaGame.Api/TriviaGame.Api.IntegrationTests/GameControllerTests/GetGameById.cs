using TriviaGame.Api.IntegrationTests.TestHelpers;
using TriviaGame.Api.Models.Dtos;

namespace TriviaGame.Api.IntegrationTests.GameControllerTests;

public class GetGameById : GameControllerTestBase, IClassFixture<ApplicationFixture>
{
    public GetGameById(ApplicationFixture fixture) : base(fixture) { }

    [Fact]
    public async Task GetGameById_Exists_Returns_Ok()
    {
        // Arrange
        var url = $"{TestUrl}/{TestIds.Game1}";
        var expected = new GameDto
        {
            Id = TestIds.Game1,
            Name = "Game One",
            ValueSymbol = "$",
            RoundIds = new List<string>
            {
                TestIds.Game1_Round1,
                TestIds.Game1_Round2
            }
        };

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<GameDto>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetGameById_DoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{TestUrl}/{Guid.NewGuid()}";

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetGameByIdIdIsNotGUId_Returns_BadRequest()
    {
        // Arrange
        var url = $"{TestUrl}/Not_A_Real_Id";

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }
}
