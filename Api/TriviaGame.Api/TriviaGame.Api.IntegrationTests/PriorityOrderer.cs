using Xunit.Abstractions;
using Xunit.Sdk;

namespace TriviaGame.Api.IntegrationTests;

[AttributeUsage(AttributeTargets.Method)]
public class TestPriorityAttribute : Attribute
{
    public TestPriorityAttribute(int priority)
    {
        Priority = priority;
    }

    public int Priority { get; private set; }
}

/// <summary>
/// Allows for tests to be run in a specified order based on TestPriorityAttribute value.
/// If if attribute is not supplied, priority of 0 is assumed.
/// 
/// NOTE: This attribute only works on a single class at a time. If there are tests across multiple files,
/// we need to use partial classes to allow the tests to act as a single class during runtime.
/// </summary>
public class PriorityOrderer : ITestCaseOrderer
{
    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(
        IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
    {
        var assemblyName = typeof(TestPriorityAttribute).AssemblyQualifiedName!;
        var sortedMethods = new SortedDictionary<int, List<TTestCase>>();
        foreach (var testCase in testCases)
        {
            var priority = testCase.TestMethod.Method
                .GetCustomAttributes(assemblyName)
                .FirstOrDefault()
                ?.GetNamedArgument<int>(nameof(TestPriorityAttribute.Priority)) ?? 0;

            GetOrCreate(sortedMethods, priority).Add(testCase);
        }

        foreach (var testCase in
                 sortedMethods.Keys.SelectMany(
                     priority => sortedMethods[priority].OrderBy(
                         testCase => testCase.TestMethod.Method.Name)))
        {
            yield return testCase;
        }
    }

    private static TValue GetOrCreate<TKey, TValue>(
        IDictionary<TKey, TValue> dictionary, TKey key)
        where TKey : struct
        where TValue : new() =>
        dictionary.TryGetValue(key, out var result)
            ? result
            : dictionary[key] = new TValue();
}
