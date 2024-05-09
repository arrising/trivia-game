namespace TriviaGame.Api.Converters.Interfaces;

public interface IConverter<in TSource, out TResult>
{
    TResult Convert(TSource value);
}
