using TriviaGame.Api.Validators.Interfaces;

namespace TriviaGame.Api.UnitTests.TestHelpers;

public static class IdValidatorHelpers
{
    /// <summary>
    ///     Setup mock to return <b>true</b> with new <b>TestException</b>
    /// </summary>
    /// <param name="mock">Mock to setup</param>
    /// <param name="id">Id to evaluate</param>
    /// <param name="parameterName">Parameter name of id input</param>
    public static Mock<IIdValidator> ReturnsWithException(this Mock<IIdValidator> mock, string id,
        string parameterName)
    {
        Exception exception = new TestException();

        return mock.ReturnsWithException(id, parameterName, exception);
    }

    /// <summary>
    ///     Setup mock to return <b>true</b> with supplied exception
    /// </summary>
    /// <param name="mock">Mock to setup</param>
    /// <param name="id">Id to evaluate</param>
    /// <param name="parameterName">Parameter name of id input</param>
    /// <param name="exception">Exception to return</param>
    public static Mock<IIdValidator> ReturnsWithException(this Mock<IIdValidator> mock, string id,
        string parameterName, Exception exception)
    {
        mock.Setup(x => x.TryGetValidationException(id, parameterName, out exception))
            .Returns(true);

        return mock;
    }

    /// <summary>
    ///     Setup mock to return <b>false</b> with null exception
    /// </summary>
    /// <param name="mock">Mock to setup</param>
    /// <param name="id">Id to evaluate</param>
    /// <param name="parameterName">Parameter name of id input</param>
    public static Mock<IIdValidator> ReturnsAsValid(this Mock<IIdValidator> mock, string id,
        string parameterName)
    {
        Exception exception = null;
        mock.Setup(x => x.TryGetValidationException(id, parameterName, out exception))
            .Returns(false);

        return mock;
    }
}
