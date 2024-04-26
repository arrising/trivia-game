using TriviaGame.Api.Factories.Interfaces;
using TriviaGame.Api.Models.Entities;
using TriviaGame.Api.Models.Requests;

namespace TriviaGame.Api.Factories;

public class GameFactory : IFactory<CreateGameRequest, GameEntity>
{
    private readonly IFactory<CreateRoundRequest, RoundEntity> _roundFactory;

    public GameFactory(IFactory<CreateRoundRequest, RoundEntity> roundFactory)
    {
        _roundFactory = roundFactory;
    }

    public GameEntity Create(CreateGameRequest options)
    {
        var gameId = Guid.NewGuid();
        var gameName = "New Game";
        var rounds = Enumerable.Range(1, options.RoundsPerGame).ToList().Select(number =>
        {
            var roundRequest = new CreateRoundRequest
            {
                GameId = gameId,
                GameName = gameName,
                RoundNumber = number,
                QuestionBaseValue = options.QuestionBaseValue * number,
                CategoriesPerRound = options.CategoriesPerRound,
                QuestionsPerCategory = options.QuestionsPerCategory
            };
            return _roundFactory.Create(roundRequest);
        }).ToList();

        return new GameEntity
        {
            Id = gameId,
            Name = gameName,
            ValueSymbol = options.ValueSymbol,
            Rounds = rounds
        };
    }
}
