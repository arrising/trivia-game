namespace TriviaGame.Api.Exceptions;

public class ConversionNullException : ArgumentNullException
{
    public ConversionNullException(string parameterName) : base(parameterName,
        $"Can not create new {parameterName} from null") { }
}
