using EndpointFiltersExample;
using EndpointFiltersExample.Accessor;
using EndpointFiltersExample.DataFactory;
using EndpointFiltersExample.Filters;
using EndpointFiltersExample.Middleware;
using EndpointFiltersExample.Verifier;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var services = builder.Services;
services.AddSingleton<AuthContextAccessor>();

services.AddScoped<IAuthorizedRequestVerifier<NewData>, NewDataVerifier>();
services.AddScoped<IRequestDataFactory<NewData>, NewDataFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.UseMiddleware<AuthExtractionMiddleware>();

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .AddEndpointFilter<EndpointAuthorizationFilter<NewData>>()
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

namespace EndpointFiltersExample
{
    record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}