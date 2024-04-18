using System.Text.Json;
using TriviaGame.Api.Data.InMemoryDb.Configuration;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data;

public class SeedDataFactory
{
    public SeedData BuildGameSeedData()
    {
        using var fileStream = new FileStream(InMemoryDbConstants.SeedDataFile, FileMode.Open);
        using var streamReader = new StreamReader(fileStream);
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var games = JsonSerializer.Deserialize<List<GameEntity>>(fileStream, options) ?? new List<GameEntity>();

        var seedData = ExtractSeedData(games);

        return seedData;
    }

    private SeedData ExtractSeedData(List<GameEntity> games)
    {
        var seedData = new SeedData();

        foreach (var game in games)
        {
            ExtractRounds(game, seedData);
            seedData.Games.Add(game);
        }

        return seedData;
    }

    private void ExtractRounds(GameEntity game, SeedData seedData)
    {
        foreach (var round in game.Rounds)
        {
            round.GameId = game.Id;
            round.Game = game;
            ExtractCategories(round, seedData);
            seedData.Rounds.Add(round);
        }
    }

    private void ExtractCategories(RoundEntity round, SeedData seedData)
    {
        foreach (var category in round.Categories)
        {
            category.RoundId = round.Id;
            category.Round = round;
            ExtractQuestions(category, seedData);
            seedData.Categories.Add(category);
        }
    }

    private void ExtractQuestions(CategoryEntity category, SeedData seedData)
    {
        foreach (var question in category.Questions)
        {
            question.CategoryId = category.Id;
            question.Category = category;
            seedData.Questions.Add(question);
        }
    }
}
