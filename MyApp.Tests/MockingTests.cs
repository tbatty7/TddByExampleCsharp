using Moq;
using MyApp.Core;

namespace MyApp.Tests;

public class MockingTests
{
    [Fact]
    public void testSomething()
    {
        // Arrange
        var mockRng = new Mock<IRandom>(MockBehavior.Strict);

        // The summaries array has length 10.
        // We expect 5 calls to Next(length), one per forecast.
        mockRng
            .SetupSequence(r => r.Next(
                It.Is<int>(len => len == 10)))
            .Returns(0)
            .Returns(1)
            .Returns(2)
            .Returns(3)
            .Returns(4);

        mockRng
            .Setup(r => r.Next(
                It.IsAny<int>(),
                It.IsAny<int>()))
            .Returns(42);
        // We also expect 5 calls to Next(-20, 55) for temperatures.
        mockRng
            .Setup(r => r.Next(-20, 55))
            .Returns(42); // any deterministic value

        // Act
        var forecasts = WeatherService.ProvideWeatherForecasts(mockRng.Object);

        // Assert
        Assert.Equal(5, forecasts.Length);
        var expectedSummaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild" };
        Assert.True(forecasts.Select(f => f.Summary).SequenceEqual(expectedSummaries));
        Assert.All(forecasts, f => Assert.Equal(42, f.TemperatureC));

        // Verify the expected interactions
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