using System.ComponentModel.DataAnnotations;

namespace TriviaGame.Api.Models.Requests;

public class CreateRoundRequest
{
    [Required]
    public Guid GameId { get; set; }

    [Required]
    public string GameName { get; set; }

    [Range(1, 10)]
    public int RoundNumber { get; init; }


    [Range(1, 10)]
    public int CategoriesPerRound { get; init; }

    [Range(1, 10)]
    public int QuestionsPerCategory { get; init; }

    [Range(1, 10)]
    public int QuestionBaseValue { get; init; }
}
