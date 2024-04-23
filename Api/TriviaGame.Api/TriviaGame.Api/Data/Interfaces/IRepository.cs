namespace TriviaGame.Api.Data.Interfaces;

public interface IRepository<out T>
{
    public T? GetById(Guid id);
    public IEnumerable<T> GetByParentId(Guid id);
    public IEnumerable<T> GetAll();
}
