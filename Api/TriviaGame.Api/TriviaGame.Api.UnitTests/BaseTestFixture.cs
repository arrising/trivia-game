using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.UnitTests;

public abstract class BaseTestFixture<T> where T : class
{
    // Entity Framework parent object references to exclude
    // Used to prevent circular reference exceptions when AutoFixture is creating values.
    private readonly Dictionary<Type, IEnumerable<string>> _entityExclusionTypes = new()
    {
        { typeof(CategoryEntity), new[] { nameof(CategoryEntity.Round) } },
        { typeof(QuestionEntity), new[] { nameof(QuestionEntity.Category) } },
        { typeof(RoundEntity), new[] { nameof(RoundEntity.Game) } }
    };

    public MockRepository Repository = new(MockBehavior.Strict);

    protected BaseTestFixture()
    {
        AutoFixture.Customizations.Add(new EntityReferenceOmitter(_entityExclusionTypes));
    }

    public IFixture AutoFixture { get; } = new Fixture();

    public abstract T CreateInstance();
}
