using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TriviaGame.Api.Models;

[ExcludeFromCodeCoverage]
public class Game
{
    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
    public string ValueSymbol { get; set; }
    public IEnumerable<Round> Rounds { get; set; } = new List<Round>();
}
