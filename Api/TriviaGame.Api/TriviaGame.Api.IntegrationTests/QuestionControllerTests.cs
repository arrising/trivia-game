using TriviaGame.Api.IntegrationTests.TestHelpers;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.IntegrationTests;

// Required to assure shard ApplicationFixture is only created once
[Collection("IntegrationTests")]
public class QuestionControllerTests
{
    private readonly ApplicationFixture _fixture;
    private readonly string _testUrl = "api/questions";

    public QuestionControllerTests(ApplicationFixture fixture)
    {
        _fixture = fixture;
    }

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

    [Theory]
    [MemberData(nameof(GetQuestionByIdData))]
    public async Task GetQuestionById_Exists_Returns_Ok(string description, string id,
        QuestionDto expected)
    {
        // Arrange
        var url = $"{_testUrl}/{id}";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<QuestionDto>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetQuestionById_DoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{_testUrl}/{Guid.NewGuid()}";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetQuestionById_IdIsNotGuid_Returns_BadRequest()
    {
        // Arrange
        var url = $"{_testUrl}/Not_A_Real_Id";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetQuestionsByCategoryId_Exists_Returns_Ok()
    {
        // Arrange
        var url = $"{_testUrl}/byCategoryId/{TestIds.Game1_Round1_Cat2}";
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
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<IEnumerable<QuestionDto>>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetQuestionsByCategoryId_DoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{_testUrl}/byCategoryId/{Guid.NewGuid()}";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetQuestionsByCategoryId_IdIsNotGUID_Returns_BadRequest()
    {
        // Arrange
        var url = $"{_testUrl}/byCategoryId/Not_A_Real_Id";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }
}
