namespace TriviaGame.Api.Models.Dtos;

public class SimpleErrorDto
{
    public SimpleErrorDto(Exception exception)
    {
        Message = exception.Message;
    }

    public string Message { get; set; }
}
