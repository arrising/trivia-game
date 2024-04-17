using TriviaGame.Api.Converters.Interfaces;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Converters;

public class QuestionPointerConverter : IConverter<QuestionEntity, QuestionPointerDto>
{
    public QuestionPointerDto Covert(QuestionEntity value) => value != null
        ? new QuestionPointerDto
        {
            Id = value.Id,
            Value = value.Value
        }
        : null;
}
