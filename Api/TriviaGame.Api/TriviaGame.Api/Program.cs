using Microsoft.OpenApi.Models;
using TriviaGame.Api.Data.InMemoryDb.Configuration;
using TriviaGame.Api.Middleware.Configuration;
using TriviaGame.Api.Services.Configuration;
using TriviaGame.Api.Validators.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Trivia Game API"
    });
});
builder.Services
    .UseInMemoryDatabase()
    .UseApplicationServices()
    .UseApplicationValidators();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => { options.DocumentTitle = "Trivia Game API"; });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseApplicationMiddleware();

app.Run();

public partial class Program { }
