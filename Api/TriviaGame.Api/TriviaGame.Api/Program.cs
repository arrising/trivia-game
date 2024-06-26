using Microsoft.OpenApi.Models;
using TriviaGame.Api.Data.Configuration;
using TriviaGame.Api.Factories.Configuration;
using TriviaGame.Api.Middleware.Configuration;
using TriviaGame.Api.Providers.Configuration;
using TriviaGame.Api.Validators.Configuration;

const string applicationCorsPolicy = "_applicationCorsPolicy";

var builder = WebApplication.CreateBuilder(args);

Console.Title = builder.Configuration["ApiName"] ?? builder.Environment.ApplicationName;

// Add services to the container.
builder.Services.AddControllers(options => options.UseApplicationActionFilters());

// Enable CORS for local host
builder.Services.AddCors(options =>
{
    options.AddPolicy(applicationCorsPolicy,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200");
            policy.AllowAnyMethod();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = builder.Configuration["ApiVersion"],
        Title = builder.Configuration["ApiName"]
    });
});

builder.Services
    .AddApplicationDataServices(builder.Configuration)
    .AddApplicationFactories()
    .AddApplicationProviders()
    .AddApplicationValidators();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Configuration.GetValue<bool>("UseSwagger"))
{
    app.UseSwagger();
    app.UseSwaggerUI(options => { options.DocumentTitle = builder.Configuration["ApiName"]; });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(applicationCorsPolicy);

app.MapControllers();

app.UseApplicationMiddleware();

app.SetupDatabaseSeedData(builder.Configuration);

app.Run();

public partial class Program { }
