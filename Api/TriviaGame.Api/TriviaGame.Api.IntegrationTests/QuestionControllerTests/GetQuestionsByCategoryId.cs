using TriviaGame.Api.IntegrationTests.TestHelpers;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.IntegrationTests.QuestionControllerTests;

public class GetQuestionsByCategoryId : QuestionControllerTestBase
{
    public GetQuestionsByCategoryId(ApplicationFixture fixture) : base(fixture) { }


    [Fact]
    public async Task GetQuestionsByCategoryId_Exists_Returns_Ok()
    {
        // Arrange
        var url = $"{TestUrl}/byCategoryId/{TestIds.Game1_Round1_Cat2}";
        var expected = new List<QuestionDto>
        {
            new()
            {
                Id = TestIds.Game1_Round1_Cat2_Q1,
                Value = 100,
                Ask = "Game One Single Category Two Question One",
                Answer = "Game One Single Category Two Answer One"
            },
            new()
            {
                Id = TestIds.Game1_Round1_Cat2_Q2,
                Value = 200,
                Ask = "Game One Single Category Two Question Two",
                Answer = "Game One Single Category Two Answer Two"
            },
            new()
            {
                Id = TestIds.Game1_Round1_Cat2_Q3,
                Value = 300,
                Ask = "Game One Single Category Two Question Three",
                Answer = "Game One Single Category Two Answer Three"
            },
            new()
            {
                Id = TestIds.Game1_Round1_Cat2_Q4,
                Value = 400,
                Ask = "Game One Single Category Two Question Four",
                Answer = "Game One Single Category Two Answer Four"
            },
            new()
            {
                Id = TestIds.Game1_Round1_Cat2_Q5,
                Value = 500,
                Ask = "Game One Single Category Two Question Five",
                Answer = "Game One Single Category Two Answer Five"
            }
        };

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<IEnumerable<QuestionDto>>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetQuestionsByCategoryId_DoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{TestUrl}/byCategoryId/{Guid.NewGuid()}";

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetQuestionsByCategoryId_IdIsNotGUID_Returns_BadRequest()
    {
        // Arrange
        var url = $"{TestUrl}/byCategoryId/Not_A_Real_Id";

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }
}
