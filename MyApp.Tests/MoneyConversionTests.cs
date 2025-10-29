using FluentAssertions;

namespace MyApp.Tests;

public class MoneyConversionTests
{
    [Fact]
    public void testMultiplication()
    {
        Dollar five = new Dollar(5);
        Dollar product = five.times(2);
        product.Amount.Should().Be(10);
        Assert.Equal(10, product.Amount);

        Dollar product2 = five.times(3);
        product2.Amount.Should().Be(15);
        Assert.Equal(15, product2.Amount);
    }

    [Fact]
    public void testEquality()
    {
        Assert.True(new Dollar(5).Equals(new Dollar(5)));
        Assert.False(new Dollar(5).Equals(new Dollar(6)));
    }
}