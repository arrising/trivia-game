using TriviaGame.Api.IntegrationTests.TestHelpers;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Requests;

namespace TriviaGame.Api.IntegrationTests.GameControllerTests;

/// <summary>
///     Using TestPriority 2 on all tests to assure these tests run after all read tests are completed
/// </summary>
public partial class GameControllerTests
{
    private static CreateGameRequest CreateGameRequest => new()
    {
        GameName = "New Test Game",
        ValueSymbol = "#",
        RoundsPerGame = 2,
        CategoriesPerRound = 2,
        QuestionsPerCategory = 3,
        QuestionBaseValue = 100
    };

    [Fact]
    [TestPriority(2)]
    public async Task CreateGame_CreatesGame_Returns_Ok()
    {
        // Arrange
        var expected = new GameDto
        {
            Id = "NewId",
            Name = "New Test Game",
            ValueSymbol = "#",
            RoundIds = new List<string>
            {
                "NewId1",
                "NewId2"
            }
        };

        // Act
        var response = await Fixture.Client.PostAsync(TestUrl, CreateContent(CreateGameRequest));

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.Created);

        var actual = await response.DeserializeContentAsync<GameDto>();

        actual.Should().BeEquivalentTo(expected, options => options
            .Excluding(x => x.Id)
            .Excluding(x => x.RoundIds));

        // - Verify game has an id
        actual.Id.Should().NotBeEmpty();

        // - Verify all rounds have an id
        actual.RoundIds
            .Should().HaveCount(2)
            .And.OnlyContain(x => !string.IsNullOrWhiteSpace(x));
    }

    [Fact]
    [TestPriority(2)]
    public async Task CreateGame_CreatesRounds_Returns_Ok()
    {
        // Arrange
        var expected = new List<RoundDto>
        {
            new()
            {
                Type = "New_Test_Game_Round1"
            },
            new()
            {
                Type = "New_Test_Game_Round2"
            }
        };

        // - Setup new Game
        var createResponse = await Fixture.Client.PostAsync(TestUrl, CreateContent(CreateGameRequest));
        createResponse.Should().BeSuccessful();
        var game = await createResponse.DeserializeContentAsync<GameDto>();
        var gameId = game.Id;

        var url = $"api/rounds/byGameId/{gameId}";

        // Act
        var response = await Fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var actual = await response.DeserializeContentAsync<IEnumerable<RoundDto>>();

        actual.Should().BeEquivalentTo(expected, options => options
            .Excluding(x => x.Id)
            .Excluding(x => x.CategoryIds));

        // - Verify all rounds have an id
        actual.Should().OnlyContain(x => !string.IsNullOrWhiteSpace(x.Id));

        // - Verify all categories have an id
        actual.SelectMany(x => x.CategoryIds)
            .Should().HaveCount(4)
            .And.OnlyContain(x => !string.IsNullOrWhiteSpace(x));
    }

    [Fact]
    [TestPriority(2)]
    public async Task CreateGame_CreatesCategories_Returns_Ok()
    {
        // Arrange
        var expected = new List<CategoryDto>
        {
            new()
            {
                Name = "New_Test_Game_Round1_Category1",
                Questions = new List<QuestionPointerDto>
                {
                    new()
                    {
                        Value = 100
                    },
                    new()
                    {
                        Value = 200
                    }
                }
            },
            new()
            {
                Name = "New_Test_Game_Round1_Category2",
                Questions = new List<QuestionPointerDto>
                {
                    new()
                    {
                        Value = 100
                    },
                    new()
                    {
                        Value = 200
                    }
                }
            },
            new()
            {
                Name = "New_Test_Game_Round2_Category1",
                Questions = new List<QuestionPointerDto>
                {
                    new()
                    {
                        Value = 200
                    },
                    new()
                    {
                        Value = 400
                    }
                }
            },
            new()
            {
                Name = "New_Test_Game_Round2_Category2",
                Questions = new List<QuestionPointerDto>
                {
                    new()
                    {
                        Value = 200
                    },
                    new()
                    {
                        Value = 400
                    }
                }
            }
        };

        // - Setup new Game
        var createResponse = await Fixture.Client.PostAsync(TestUrl, CreateContent(CreateGameRequest));
        createResponse.Should().BeSuccessful();
        var game = await createResponse.DeserializeContentAsync<GameDto>();
        var gameId = game.Id;

        // - Get rounds
        var getRoundUrl = $"api/rounds/byGameId/{gameId}";
        var roundResponse = await Fixture.Client.GetAsync(getRoundUrl);
        roundResponse.Should().BeSuccessful();
        var rounds = await roundResponse.DeserializeContentAsync<IEnumerable<RoundDto>>();

        // Act
        var responses = rounds.Select(round =>
        {
            var url = $"api/categories/byRoundId/{round.Id}";
            return Fixture.Client.GetAsync(url);
        }).ToList();

        await Task.WhenAll(responses);

        // Assert
        responses.Should().OnlyContain(x => x.IsCompletedSuccessfully);

        var actual = new List<CategoryDto>();
        foreach (var response in responses)
        {
            var result = await response.Result.DeserializeContentAsync<IEnumerable<CategoryDto>>();
            actual.AddRange(result);
        }

        actual.Should().BeEquivalentTo(expected, options => options
            .Excluding(x => x.Id)
            .For(x => x.Questions)
            .Exclude(y => y.Id));

        // - Verify all categories have an id
        actual.Should().OnlyContain(x => !string.IsNullOrWhiteSpace(x.Id));

        // - Verify all questions have an id
        actual.SelectMany(category => category.Questions.Select(q => q.Id))
            .Should().HaveCount(8)
            .And.OnlyContain(x => !string.IsNullOrWhiteSpace(x));
    }

    [Fact]
    [TestPriority(2)]
    public async Task CreateGame_CreatesQuestions_Returns_Ok()
    {
        // Arrange
        var expected = new List<QuestionDto>
        {
            new()
            {
                Value = 100,
                Ask = "New_Test_Game_Round1_Category1_Question1",
                Answer = "New_Test_Game_Round1_Category1_Answer1"
            },
            new()
            {
                Value = 200,
                Ask = "New_Test_Game_Round1_Category1_Question2",
                Answer = "New_Test_Game_Round1_Category1_Answer2"
            },
            new()
            {
                Value = 100,
                Ask = "New_Test_Game_Round1_Category2_Question1",
                Answer = "New_Test_Game_Round1_Category2_Answer1"
            },
            new()
            {
                Value = 200,
                Ask = "New_Test_Game_Round1_Category2_Question2",
                Answer = "New_Test_Game_Round1_Category2_Answer2"
            },


            new()
            {
                Value = 200,
                Ask = "New_Test_Game_Round2_Category1_Question1",
                Answer = "New_Test_Game_Round2_Category1_Answer1"
            },
            new()
            {
                Value = 400,
                Ask = "New_Test_Game_Round2_Category1_Question2",
                Answer = "New_Test_Game_Round2_Category1_Answer2"
            },
            new()
            {
                Value = 200,
                Ask = "New_Test_Game_Round2_Category2_Question1",
                Answer = "New_Test_Game_Round2_Category2_Answer1"
            },
            new()
            {
                Value = 400,
                Ask = "New_Test_Game_Round2_Category2_Question2",
                Answer = "New_Test_Game_Round2_Category2_Answer2"
            }
        };

        // - Setup new Game
        var createResponse = await Fixture.Client.PostAsync(TestUrl, CreateContent(CreateGameRequest));
        createResponse.Should().BeSuccessful();
        var game = await createResponse.DeserializeContentAsync<GameDto>();
        var gameId = game.Id;

        // - Get rounds
        var getRoundUrl = $"api/rounds/byGameId/{gameId}";
        var roundResponse = await Fixture.Client.GetAsync(getRoundUrl);
        roundResponse.Should().BeSuccessful();
        var rounds = (await roundResponse.DeserializeContentAsync<IEnumerable<RoundDto>>() ?? Array.Empty<RoundDto>())
            .ToList();

        // - Get categories
        var categoryResponses = rounds.Select(round =>
        {
            var url = $"api/categories/byRoundId/{round.Id}";
            return Fixture.Client.GetAsync(url);
        }).ToList();
        await Task.WhenAll(categoryResponses);
        categoryResponses.Should().OnlyContain(x => x.IsCompletedSuccessfully);
        var categories = new List<CategoryDto>();
        foreach (var response in categoryResponses)
        {
            var result = await response.Result.DeserializeContentAsync<IEnumerable<CategoryDto>>();
            categories.AddRange(result);
        }

        // Act
        var responses = categories.Select(category =>
        {
            var url = $"api/questions/byCategoryId/{category.Id}";
            return Fixture.Client.GetAsync(url);
        }).ToList();

        await Task.WhenAll(responses);

        // Assert
        responses.Should().OnlyContain(x => x.IsCompletedSuccessfully);

        var actual = new List<QuestionDto>();
        foreach (var response in responses)
        {
            var result = await response.Result.DeserializeContentAsync<IEnumerable<QuestionDto>>();
            actual.AddRange(result);
        }

        var actualFirst = actual.Last();
        var expectedFirst = expected.Last();

        actualFirst.Should().BeEquivalentTo(expectedFirst, options => options.Excluding(x => x.Id));

        actual.Should().BeEquivalentTo(expected, options => options
            .Excluding(x => x.Id));

        // - Verify all questions have an id
        actual.Should().OnlyContain(x => !string.IsNullOrWhiteSpace(x.Id));
    }
}
