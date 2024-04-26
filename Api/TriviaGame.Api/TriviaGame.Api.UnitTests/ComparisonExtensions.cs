using FluentAssertions.Equivalency;

namespace TriviaGame.Api.UnitTests;

public static class ComparisonExtensions
{
    public static T WhenEquivalent<T>(this T actual, T expected)
    {
        return It.Is<T>(x => x.IsEquivalentTo(expected));
    }

    public static T WhenEquivalent<T>(this T actual, T expected,
        Func<EquivalencyAssertionOptions<T>, EquivalencyAssertionOptions<T>> options)
    {
        return It.Is<T>(x => x.IsEquivalentTo(expected, options));
    }

    public static bool IsEquivalentTo<T>(this T actual, T expected)
    {
        try
        {
            actual.Should().BeEquivalentTo(expected);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool IsEquivalentTo<T>(this T actual, T expected,
        Func<EquivalencyAssertionOptions<T>, EquivalencyAssertionOptions<T>> options)
    {
        try
        {
            actual.Should().BeEquivalentTo(expected, options);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
