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
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<CategoryDto>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetCategoryById_DoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{_testUrl}/{Guid.NewGuid()}";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetCategoryById_IdIsNotGUID_Returns_BadRequest()
    {
        // Arrange
        var url = $"{_testUrl}/Not_A_Real_Id";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetCategoriesByRoundId_Exists_Returns_Ok()
    {
        // Arrange
        var url = $"{_testUrl}/byRoundId/{TestIds.Game1_Round1}";
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
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<IEnumerable<CategoryDto>>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetCategoryByRoundId_DoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{_testUrl}/byRoundId/{Guid.NewGuid()}";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetCategoryByRoundId_IdIsNotGuid_Returns_BadRequest()
    {
        // Arrange
        var url = $"{_testUrl}/byRoundId/Not_A_Real_Id";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }
}
