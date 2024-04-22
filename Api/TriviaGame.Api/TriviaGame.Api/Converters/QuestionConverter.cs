using TriviaGame.Api.Converters.Interfaces;
using TriviaGame.Api.Models.Dtos;
using TriviaGame.Api.Models.Entities;

namespace TriviaGame.Api.Converters;

public class QuestionConverter : IConverter<QuestionEntity, QuestionDto>
{
    public QuestionDto Covert(QuestionEntity value) => value != null ? new QuestionDto(value) : null;
}
