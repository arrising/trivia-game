﻿namespace TriviaGame.Api.Models;

public class Round
{
    public string Id { get; set; }
    public string GameId { get; set; }
    public string Type { get; set; }
    public IEnumerable<Category> Categories { get; set; }
}
