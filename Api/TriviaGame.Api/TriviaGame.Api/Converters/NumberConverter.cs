using TriviaGame.Api.Converters.Interfaces;

namespace TriviaGame.Api.Converters;

public class NumberConverter : IConverter<int, string>
{
    // For better version, see https://stackoverflow.com/a/2730393;
    private readonly string[] _unitsMap =
        { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };

    public string Convert(int value) => value < _unitsMap.Length ? _unitsMap[value] : value.ToString();
}
