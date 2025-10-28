using System;
using System.Linq;

namespace MyApp.Core;

public static class WeatherService
{
    public static WeatherForecast[] ProvideWeatherForecasts()
    {
        var weatherSummaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering",
            "Scorching"
        };

        var weatherForecasts = Enumerable.Range(1, 5).Select(index =>
        {
            var next = Random.Shared.Next(weatherSummaries.Length);
            return new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                weatherSummaries[next]
            );
        }).ToArray();

        return weatherForecasts;
    }
}