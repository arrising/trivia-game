namespace TriviaGame.Api.Converters.Interfaces;

public interface IConverter<in TInput, out TOutput>
{
    TOutput Covert(TInput value);
}
