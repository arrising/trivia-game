namespace TriviaGame.Api.Data.Interfaces;

public interface IRepository<out T>
{
    public T GetById(string id);
    public IEnumerable<T> GetByParentId(string id);
    public IEnumerable<T> GetAll();
}
