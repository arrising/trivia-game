namespace TriviaGame.Api.Data.Interfaces;

public interface IRepository<T>
{
    Task<T> Add(T value, CancellationToken token);
    public T? GetById(Guid id);
    public IEnumerable<T> GetByParentId(Guid id);
    public IEnumerable<T> GetAll();
}
