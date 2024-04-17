using TriviaGame.Api.IntegrationTests.TestHelpers;
using TriviaGame.Api.Models.Dtos;

namespace TriviaGame.Api.IntegrationTests.GameControllerTests;

public class GetAllGames : GameControllerTestBase
{
    public GetAllGames(ApplicationFixture fixture) : base(fixture) { }

    public override string TestUrl => "api/games";

    [Fact]
    public async Task GetAllGames_Returns_Ok()
    {
        // Arrange
        var expected = new List<GameDto>
        {
            new()
            {
                Id = "d12adfa5-26b5-4a6b-bd65-2dd02768437f",
                Name = "Game One",
                ValueSymbol = "$",
                RoundIds = new List<string>
                {
                    TestIds.Game1_Round1,
                    TestIds.Game1_Round2
                }
            },
            new()
            {
                Id = "71807a01-8dc2-40b9-ac9c-6977c3371357",
                Name = "Game Two",
                ValueSymbol = "$",
                RoundIds = new List<string>
                {
                    TestIds.Game2_Round1,
                    TestIds.Game2_Round2
                }
            }
        };

        // Act
        var response = await Fixture.Client.GetAsync(TestUrl);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<IEnumerable<GameDto>>();

        result.Should().BeEquivalentTo(expected);
    }
}
