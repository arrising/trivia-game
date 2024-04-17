using TriviaGame.Api.IntegrationTests.TestHelpers;
using TriviaGame.Api.Models.Dtos;

namespace TriviaGame.Api.IntegrationTests.CategoryControllerTests;

public class GetCategoriesByRoundId : CategoryControllerTestBase
{
    public GetCategoriesByRoundId(ApplicationFixture fixture) : base(fixture) { }

    [Fact]
    public async Task GetCategoriesByRoundId_Exists_Returns_Ok()
    {
        // Arrange
        var url = $"{TestUrl}/byRoundId/{TestIds.Game1_Round1}";
        var expected = new List<CategoryDto>
        {
            new()
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
            },
            new()
            {
                Id = TestIds.Game1_Round1_Cat2,
                Name = "Game One Single Category Two",
                Questions = new List<QuestionPointerDto>
                {
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat2_Q1,
                        Value = 100
                    },
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat2_Q2,
                        Value = 200
                    },
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat2_Q3,
                        Value = 300
                    },
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat2_Q4,
                        Value = 400
                    },
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat2_Q5,
                        Value = 500
                    }
                }
            },
            new()
            {
                Id = TestIds.Game1_Round1_Cat3,
                Name = "Game One Single Category Three",
                Questions = new List<QuestionPointerDto>
                {
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat3_Q1,
                        Value = 100
                    },
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat3_Q2,
                        Value = 200
                    },
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat3_Q3,
                        Value = 300
                    },
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat3_Q4,
                        Value = 400
                    },
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat3_Q5,
                        Value = 500
                    }
                }
            },
            new()
            {
                Id = TestIds.Game1_Round1_Cat4,
                Name = "Game One Single Category Four",
                Questions = new List<QuestionPointerDto>
                {
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat4_Q1,
                        Value = 100
                    },
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat4_Q2,
                        Value = 200
                    },
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat4_Q3,
                        Value = 300
                    },
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat4_Q4,
                        Value = 400
                    },
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat4_Q5,
                        Value = 500
                    }
                }
            },
            new()
            {
                Id = TestIds.Game1_Round1_Cat5,
                Name = "Game One Single Category Five",
                Questions = new List<QuestionPointerDto>
                {
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat5_Q1,
                        Value = 100
                    },
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat5_Q2,
                        Value = 200
                    },
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat5_Q3,
                        Value = 300
                    },
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat5_Q4,
                        Value = 400
                    },
                    new()
                    {
                        Id = TestIds.Game1_Round1_Cat5_Q5,
                        Value = 500
                    }
                }
            }
        };

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<IEnumerable<CategoryDto>>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetCategoryByRoundId_DoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{TestUrl}/byRoundId/{Guid.NewGuid()}";

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetCategoryByRoundId_IdIsNotGuid_Returns_BadRequest()
    {
        // Arrange
        var url = $"{TestUrl}/byRoundId/Not_A_Real_Id";

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }
}
