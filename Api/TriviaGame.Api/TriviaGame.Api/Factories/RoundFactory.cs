using TriviaGame.Api.Factories.Interfaces;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Models.Requests;

namespace TriviaGame.Api.Factories;

public class RoundFactory : IFactory<CreateRoundRequest, RoundEntity>
{
    private readonly IFactory<CreateCategoryRequest, CategoryEntity> _categoryFactory;

    public RoundFactory(IFactory<CreateCategoryRequest, CategoryEntity> categoryFactory)
    {
        _categoryFactory = categoryFactory;
    }

    public RoundEntity Create(CreateRoundRequest options)
    {
        var roundId = Guid.NewGuid();
        var roundName = $"{options.GameName}_Round{options.RoundNumber}";

        var categories = Enumerable.Range(1, options.CategoriesPerRound).ToList().Select(number =>
        {
            var categoryRequest = new CreateCategoryRequest
            {
                RoundId = roundId,
                RoundName = roundName,
                CategoryNumber = number,
                QuestionsPerCategory = options.CategoriesPerRound,
                QuestionBaseValue = options.QuestionBaseValue
            };
            return _categoryFactory.Create(categoryRequest);
        }).ToList();

        return new RoundEntity
        {
            Id = roundId,
            GameId = options.GameId,
            Type = roundName,
            Categories = categories
        };
    }
}
