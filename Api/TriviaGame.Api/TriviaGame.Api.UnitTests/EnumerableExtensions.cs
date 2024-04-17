namespace TriviaGame.Api.UnitTests;

public static class EnumerableExtensions
{
    public static void SetupTestCases<TIn>(
        this IEnumerable<TIn> source, Func<TIn> method)
    {
        foreach (var _ in source)
        {
            method.Invoke();
        }
    }

    public static IEnumerable<TOut> SetupTestCases<TIn, TOut>(
        this IEnumerable<TIn> source, Func<TIn, TOut> method) =>
        source.Select(method.Invoke).ToList();
}
