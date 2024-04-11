namespace TriviaGame.Api.Models;

public class SimpleErrorDto
{
    public SimpleErrorDto(Exception exception)
    {
        Message = exception.Message;
    }

    public string Message { get; set; }
}
