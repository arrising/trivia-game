namespace TriviaGame.Api.Exceptions;

public class ConversionNullException : ArgumentNullException
{
    public ConversionNullException(Type type, string parameterName) : base(parameterName,
        $"Can not create new {type.Name} from null") { }
}
