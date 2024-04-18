using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Data;

public class SeedData
{
    public List<CategoryEntity> Categories { get; set; } = new();
    public List<GameEntity> Games { get; set; } = new();
    public List<RoundEntity> Rounds { get; set; } = new();
    public List<QuestionEntity> Questions { get; set; } = new();
}
