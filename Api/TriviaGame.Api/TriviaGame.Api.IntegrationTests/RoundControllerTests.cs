﻿using TriviaGame.Api.IntegrationTests.TestHelpers;
using TriviaGame.Api.Models;

namespace TriviaGame.Api.IntegrationTests;

// Required to assure shard ApplicationFixture is only created once
[Collection("IntegrationTests")]
public class RoundControllerTests : IClassFixture<ApplicationFixture>
{
    private readonly ApplicationFixture _fixture;
    private readonly string _testUrl = "api/rounds";

    public RoundControllerTests(ApplicationFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GetRoundById_Exists_Returns_Ok()
    {
        // Arrange
        var url = $"{_testUrl}/{TestIds.Game1_Round1}";
        var expected = new Round
        {
            GameId = TestIds.Game1,
            Id = TestIds.Game1_Round1,
            Type = "Single"
        };

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<Round>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetRoundById_DoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{_testUrl}/{Guid.NewGuid()}";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetRoundById_IdIsNotGUID_Returns_BadRequest()
    {
        // Arrange
        var url = $"{_testUrl}/Not_A_Real_Id";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetRoundsByGameId_Exists_Returns_Ok()
    {
        // Arrange
        var url = $"{_testUrl}/byGameId/{TestIds.Game1}";
        var expected = new List<Round>
        {
            new()
            {
                GameId = TestIds.Game1,
                Id = TestIds.Game1_Round1,
                Type = "Single"
            },
            new()
            {
                GameId = TestIds.Game1,
                Id = TestIds.Game1_Round2,
                Type = "Double"
            }
        };
            
        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().BeSuccessful();

        var result = await response.DeserializeContentAsync<IEnumerable<Round>>();

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetRoundsByGameId_DoesNotExist_Returns_NotFound()
    {
        // Arrange
        var url = $"{_testUrl}/ByGameId/{Guid.NewGuid()}";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetRoundsByGameId_IdIsNotGUID_Returns_BadRequest()
    {
        // Arrange
        var url = $"{_testUrl}/ByGameId/Not_A_Real_Id";

        // Act
        var response = await _fixture.Client.GetAsync(url);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }
}
