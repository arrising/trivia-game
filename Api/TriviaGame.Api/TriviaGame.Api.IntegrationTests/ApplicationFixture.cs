using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TriviaGame.Api.IntegrationTests;

public class ApplicationFixture : IDisposable
{
    public ApplicationFixture()
    {
        var factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder => 
                builder.UseEnvironment("Integration"));
        ApplicationFactory = factory;
        Client = ApplicationFactory.CreateClient();
    }

    public WebApplicationFactory<Program> ApplicationFactory { get; }
    public HttpClient Client { get; }

    public void Dispose()
    {
        Client.Dispose();
        ApplicationFactory.Dispose();
    }
}

[CollectionDefinition("IntegrationTests")]
public class ApplicationFixtureCollection : ICollectionFixture<ApplicationFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.

    // Assures that ApplicationFixture is created only once
    // preventing resource access errors
}
