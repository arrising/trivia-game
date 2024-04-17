using TriviaGame.Api.Converters;

namespace TriviaGame.Api.UnitTests.Converters.QuestionConverterTests;

public class QuestionConverterFixture : BaseTestFixture<QuestionConverter>
{
    public override QuestionConverter CreateInstance() => new();
}
