using TriviaGame.Api.IntegrationTests.TestHelpers;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.IntegrationTests.QuestionControllerTests;

public class GetQuestionById : QuestionControllerTestBase
{
    public static TheoryData<string, string, QuestionDto> GetQuestionByIdData = new()
    {
        {
            "With One Alternative",
            TestIds.Game1_Round1_Cat1_Q1,
            new QuestionDto
            {
                Id = TestIds.Game1_Round1_Cat1_Q1,
                Value = 100,
                Ask = "Game One Single Category One Question One",
                Answer = "Game One Single Category One Answer One",
                Alternatives = new List<string>
                {
                    "Question One Alternate One"
                }
            }
        },
        {
            "With Multiple Alternatives",
            TestIds.Game1_Round1_Cat1_Q2,
            new QuestionDto
            {
                Id = TestIds.Game1_Round1_Cat1_Q2,
                Value = 200,
                Ask = "Game One Single Category One Question Two",
                Answer = "Game One Single Category One Answer Two",
                Alternatives = new List<string>
                {
                    "Question Two First Alternate",
                    "Question Two Second Alternate"
                }
            }
        },
        {
            "With Note",
            TestIds.Game1_Round1_Cat1_Q3,
            new QuestionDto
            {
                Id = TestIds.Game1_Round1_Cat1_Q3,
                Value = 300,
                Ask = "Game One Single Category One Question Three",
                Answer = "Game One Single Category One Answer Three",
                Note = "Question Three Note"
            }
        },
        {
            "With Note and Alternative",
            TestIds.Game1_Round1_Cat1_Q4,
            new QuestionDto
            {
                Id = TestIds.Game1_Round1_Cat1_Q4,
                Value = 400,
                Ask = "Game One Single Category One Question Four",
                Answer = "Game One Single Category One Answer Four",
                Note = "Question Four Note",
                Alternatives = new List<string>
                {
                    "Question Four First Alternate",
                    "Question Four Second Alternate"
                }
            }
        },
        {
            "Without Note Or  Alternatives",
            TestIds.Game1_Round1_Cat1_Q5,
            new QuestionDto
            {
                Id = TestIds.Game1_Round1_Cat1_Q5,
                Value = 500,
                Ask = "Game One Single Category One Question Five",
                Answer = "Game One Single Category One Answer Five"
            }
        }
    };

    public GetQuestionById(ApplicationFixture fixture) : base(fixture) { }

    [Theory]
    [MemberData(nameof(GetQuestionByIdData))]
    public async Task GetQuestionById_Exists_Returns_Ok(string description, string id,
        QuestionDto expected)
    {
        // Arrange
        var url = $"{TestUrl}/{id}";

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<QuestionDto>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetQuestionById_DoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{TestUrl}/{Guid.NewGuid()}";

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetQuestionById_IdIsNotGuid_Returns_BadRequest()
    {
        // Arrange
        var url = $"{TestUrl}/Not_A_Real_Id";

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }
}
