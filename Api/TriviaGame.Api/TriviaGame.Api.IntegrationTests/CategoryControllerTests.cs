using TriviaGame.Api.IntegrationTests.TestHelpers;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.IntegrationTests;

// Required to assure shard ApplicationFixture is only created once
[Collection("IntegrationTests")]
public class CategoryControllerTests
{
    private readonly ApplicationFixture _fixture;
    private readonly string _testUrl = "api/categories";

    public CategoryControllerTests(ApplicationFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GetCategoryById_Exists_Returns_Ok()
    {
        // Arrange
        var url = $"{_testUrl}/{TestIds.Game1_Round1_Cat1}";
        var expected = new Category
        {
            Id = TestIds.Game1_Round1_Cat1,
            RoundId = TestIds.Game1_Round1,
            Name = "Game One Single Category One"
        };

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<Category>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetCategoryById_DoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{_testUrl}/Not_A_Real_Id";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetCategoriesByRoundId_Exists_Returns_Ok()
    {
        // Arrange
        var url = $"{_testUrl}/byRoundId/{TestIds.Game1_Round1}";
        var expected = new List<Category>
        {
            new()
            {
                Id = TestIds.Game1_Round1_Cat1,
                RoundId = TestIds.Game1_Round1,
                Name = "Game One Single Category One"
            },
            new()
            {
                Id = TestIds.Game1_Round1_Cat2,
                RoundId = TestIds.Game1_Round1,
                Name = "Game One Single Category Two"
            },
            new()
            {
                Id = TestIds.Game1_Round1_Cat3,
                RoundId = TestIds.Game1_Round1,
                Name = "Game One Single Category Three"
            },
            new()
            {
                Id = TestIds.Game1_Round1_Cat4,
                RoundId = TestIds.Game1_Round1,
                Name = "Game One Single Category Four"
            },
            new()
            {
                Id = TestIds.Game1_Round1_Cat5,
                RoundId = TestIds.Game1_Round1,
                Name = "Game One Single Category Five"
            }
        };

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<IEnumerable<Category>>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetCategoryByRoundId_DoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{_testUrl}/byRoundId/Not_A_Real_Id";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }
}
