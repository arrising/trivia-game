using System.Diagnostics.CodeAnalysis;

namespace TriviaGame.Api.UnitTests;

[ExcludeFromCodeCoverage]
public class TestException : Exception
{
    public TestException() { }

    public TestException(string message) : base(message) { }
}
