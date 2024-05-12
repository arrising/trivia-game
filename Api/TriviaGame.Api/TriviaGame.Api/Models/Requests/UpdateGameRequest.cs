using System.ComponentModel.DataAnnotations;

namespace TriviaGame.Api.Models.Requests;

public class UpdateGameRequest : IValidatableObject
{
    [MinLength(1)]
    public string? Name { get; init; }

    [MinLength(1)]
    [MaxLength(5)]
    public string? ValueSymbol { get; init; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Name == null && ValueSymbol == null)
        {
            yield return new ValidationResult("Game Update must contain one or more non-null properties");
        }
    }
}
