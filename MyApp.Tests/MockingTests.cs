using Moq;
using MyApp.Core;

namespace MyApp.Tests;

public class MockingTests
{
    [Fact]
    public void testSomething()
    {
        var mockRng = new Mock<IRandom>(MockBehavior.Strict);

        mockRng
            .SetupSequence(r => r.Next(
                It.Is<int>(len => len == 10)))
            .Returns(0)
            .Returns(1)
            .Returns(2)
            .Returns(3)
            .Returns(4);


        mockRng
            .Setup(r => r.Next(-20, 55))
            .Returns(42); // any deterministic value

        var forecasts = WeatherService.ProvideWeatherForecasts(mockRng.Object);

        Assert.Equal(5, forecasts.Length);
        var expectedSummaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild" };
        Assert.Equal(expectedSummaries, forecasts.Select(f => f.Summary).ToList());
        Assert.All(forecasts, f => Assert.Equal(42, f.TemperatureC));

        mockRng.Verify(r => r.Next(It.Is<int>(len => len == 10)), Times.Exactly(5));
        mockRng.Verify(r => r.Next(-20, 55), Times.Exactly(5));
        mockRng.VerifyNoOtherCalls();
    }

    [Fact]
    public void EnumerableRange()
    {
        var range = Enumerable.Range(1, 5);
        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, range);
        Assert.Equal(1, range.First());
    }
}