using TriviaGame.Api.IntegrationTests.TestHelpers;
using TriviaGame.Api.Models.Dtos;

namespace TriviaGame.Api.IntegrationTests.CategoryControllerTests;

public class GetCategoryById : CategoryControllerTestBase
{
    public GetCategoryById(ApplicationFixture fixture) : base(fixture) { }

    [Fact]
    public async Task GetCategoryById_Exists_Returns_Ok()
    {
        // Arrange
        var url = $"{TestUrl}/{TestIds.Game1_Round1_Cat1}";
        var expected = new CategoryDto
        {
            Id = TestIds.Game1_Round1_Cat1,
            Name = "Game One Single Category One",
            Questions = new List<QuestionPointerDto>
            {
                new()
                {
                    Id = TestIds.Game1_Round1_Cat1_Q1,
                    Value = 100
                },
                new()
                {
                    Id = TestIds.Game1_Round1_Cat1_Q2,
                    Value = 200
                },
                new()
                {
                    Id = TestIds.Game1_Round1_Cat1_Q3,
                    Value = 300
                },
                new()
                {
                    Id = TestIds.Game1_Round1_Cat1_Q4,
                    Value = 400
                },
                new()
                {
                    Id = TestIds.Game1_Round1_Cat1_Q5,
                    Value = 500
                }
            }
        };

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<CategoryDto>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetCategoryById_DoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{TestUrl}/{Guid.NewGuid()}";

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetCategoryById_IdIsNotGUID_Returns_BadRequest()
    {
        // Arrange
        var url = $"{TestUrl}/Not_A_Real_Id";

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }
}
