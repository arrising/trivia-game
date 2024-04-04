using System.Diagnostics.CodeAnalysis;

namespace TriviaGame.Api.Data.InMemoryDb.Configuration;

[ExcludeFromCodeCoverage]
public static class InMemoryDbConstants
{
    public static string DbName = "TriviaGameDb";
    public static string SeedDataFile = "data/TriviaGameSeedData.json";
}
