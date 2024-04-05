namespace TriviaGame.Api.Validators.Interfaces
{
    public interface IIdValidator
    {
        /// <summary>
        /// Try to get validation exception for id inputs
        /// </summary>
        /// <param name="input">Value to check</param>
        /// <param name="parameterName">parameter name value came from</param>
        /// <param name="exception">Exception to throw</param>
        /// <returns>true if INVALID, false if VALID</returns>
        bool TryGetValidationException(string? input, string parameterName, out Exception exception);
    }
}
