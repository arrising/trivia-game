using System.ComponentModel.DataAnnotations;

namespace TriviaGame.Api.Models.Requests;

public class CreateGameRequest
{
    [MinLength(1)]
    public string GameName { get; set; }

    [MinLength(1)]
    [MaxLength(5)]
    public string ValueSymbol { get; init; }

    [Range(1, 1000)]
    public int QuestionBaseValue { get; init; }

    [Range(1, 10)]
    public int RoundsPerGame { get; init; }

    [Range(1, 10)]
    public int CategoriesPerRound { get; init; }

    [Range(1, 10)]
    public int QuestionsPerCategory { get; init; }
}
