var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering",
    "Scorching"
};

app.MapGet("/weatherforecast", HandleWeatherForecast(summaries))
    .WithName("GetWeatherForecast");

app.Run();

Func<WeatherForecast[]> HandleWeatherForecast(string[] weatherSummaries)
{
    return () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
            {
                var next = Random.Shared.Next(weatherSummaries.Length);
                return new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    weatherSummaries[next]
                );
            })
            .ToArray();
        return forecast;
    };
}