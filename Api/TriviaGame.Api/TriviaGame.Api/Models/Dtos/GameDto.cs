﻿using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Models.Dtos;

public class GameDto
{
    public GameDto() { }

    public GameDto(GameEntity game)
    {
        if (game == null)
        {
            throw new ConversionNullException(GetType(), nameof(game));
        }

        Id = game.Id.ToString();
        Name = game.Name;
        ValueSymbol = game.ValueSymbol;
        RoundIds = game.Rounds?.Any() == true ? game.Rounds.Select(x => x.Id.ToString()) : Enumerable.Empty<string>();
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string ValueSymbol { get; set; }
    public IEnumerable<string> RoundIds { get; set; } = Enumerable.Empty<string>();
}
