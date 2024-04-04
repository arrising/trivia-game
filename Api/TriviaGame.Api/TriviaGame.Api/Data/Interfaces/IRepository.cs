namespace TriviaGame.Api.Data.Interfaces;

public interface IRepository<T>
{
    public T GetById(string gameId);
    public IEnumerable<T> GetAll();
}
