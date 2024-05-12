namespace TriviaGame.Api.Data.Interfaces;

public interface IRepository<T>
{
    public T? GetById(Guid id);
    public IEnumerable<T> GetByParentId(Guid id);
    public IEnumerable<T> GetAll();
    public Task Update(T value);
}
