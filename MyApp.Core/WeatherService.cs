namespace MyApp.Core;

public static class WeatherService
{
    public static WeatherForecast[] ProvideWeatherForecasts()
    {
        return ProvideWeatherForecasts(new SharedRandom());
    }

    public static WeatherForecast[] ProvideWeatherForecasts(IRandom numberGenerator)
    {
        var weatherSummaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering",
            "Scorching"
        };

        var weatherForecasts = Enumerable.Range(1, 5).Select(index =>
        {
            var next = numberGenerator.Next(weatherSummaries.Length);
            return new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                numberGenerator.Next(-20, 55),
                weatherSummaries[next]
            );
        }).ToArray();

        return weatherForecasts;
    }
}