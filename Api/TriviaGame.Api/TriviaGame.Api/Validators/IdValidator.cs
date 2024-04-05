using TriviaGame.Api.Validators.Interfaces;

namespace TriviaGame.Api.Validators;

public class IdValidator : IIdValidator
{
    public bool TryGetValidationException(string? input, string parameterName, out Exception exception)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            exception = new ArgumentException($"{parameterName} must have a non empty value", parameterName);
            return true;
        }

        exception = null!;
        return false;
    }
}
