namespace TriviaGame.Api.Data.Interfaces;

/// <summary>
///     Used to modify complex entity relationship changes in a single transaction.
///     eg. A parent entity with mandatory child entities can be created in one transaction
/// </summary>
/// <typeparam name="T">Root type of entity to modify</typeparam>
public interface IComplexEntityRepository<T>
{
    Task<T> Add(T value, CancellationToken token);
}
