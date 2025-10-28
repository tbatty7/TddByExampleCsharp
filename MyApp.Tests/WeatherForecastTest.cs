using FluentAssertions;
using MyApp.Core;

namespace MyApp.Tests;

public class WeatherForecastTest
{

    [Fact]
    public void canSeeWeather()
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering",
            "Scorching"
        };
        DateOnly date = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        WeatherForecast result = new WeatherForecast
        (
            date,
            28,
            summaries[2]
        );
        result.Should().Be(new WeatherForecast(date, 28, "Chilly"));
    }

    [Fact]
    public void generatesWeatherList()
    {
        WeatherService.ProvideWeatherForecasts().Should().HaveCount(5);
    }
}