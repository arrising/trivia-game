namespace TriviaGame.Api.UnitTests;

public abstract class BaseTestFixture<T> where T : class
{
    public IFixture AutoFixture { get; } = new Fixture();
    protected MockRepository Repository = new(MockBehavior.Strict);

    public abstract T CreateInstance();
}
