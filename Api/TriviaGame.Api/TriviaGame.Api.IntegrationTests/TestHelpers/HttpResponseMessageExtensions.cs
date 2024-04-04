using Newtonsoft.Json;

namespace TriviaGame.Api.IntegrationTests.TestHelpers;

public static class HttpResponseMessageExtensions
{
    public static async Task<T?> DeserializeContentAsync<T>(this HttpResponseMessage? message)
    {
        var responseObject = default(T);
        if (message == null)
        {
            return responseObject;
        }

        var responseJson  = await message.Content.ReadAsStringAsync();
        responseObject = JsonSerializer.CreateDefault().Deserialize<T>(
            new JsonTextReader(new StringReader(responseJson)));

        return responseObject;
    }
}
