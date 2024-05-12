namespace TriviaGame.Api.UnitTests;

public static class TestData
{
    public static TheoryData<string?> InvalidIds => new()
    {
        null, string.Empty, "     ", "Not a real Guid"
    };
}
