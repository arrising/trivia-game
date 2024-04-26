using TriviaGame.Api.Factories;

namespace TriviaGame.Api.UnitTests.Factories.QuestionFactoryTests;

public class QuestionFactoryFixture : BaseTestFixture<QuestionFactory>
{
    public override QuestionFactory CreateInstance() => new();
}
