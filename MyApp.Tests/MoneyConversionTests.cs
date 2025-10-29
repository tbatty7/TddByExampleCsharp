using FluentAssertions;

namespace MyApp.Tests;

public class MoneyConversionTests
{
    [Fact]
    public void testMultiplication()
    {
        Dollar five = new Dollar(5);
        five.times(2);
        five.Amount.Should().Be(10);
        Assert.Equal(10, five.Amount);
    }
}