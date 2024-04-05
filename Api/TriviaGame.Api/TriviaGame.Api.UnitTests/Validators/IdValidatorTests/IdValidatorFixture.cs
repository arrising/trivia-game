using TriviaGame.Api.Validators;

namespace TriviaGame.Api.UnitTests.Validators.IdValidatorTests;

public class IdValidatorFixture : BaseTestFixture<IdValidator>
{
    public override IdValidator CreateInstance() => new();
}
