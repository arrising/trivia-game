namespace TriviaGame.Api.Factories.Interfaces;

public interface IFactory<in TOptions, out TResult>
{
    public TResult Create(TOptions options);
}
