using FluentAssertions;
using MyApp.Core;

namespace MyApp.Tests;

public class MoneyConversionTests
{
    [Fact]
    public void testMultiplication()
    {
        var five = Money.dollar(5);
        five.times(2).Should().Be(Money.dollar(10));
        Assert.Equal(Money.dollar(10), five.times(2));

        five.times(3).Should().Be(Money.dollar(15));
        Assert.Equal(Money.dollar(15), five.times(3));
    }

    [Fact]
    public void testEquality()
    {
        Assert.True(Money.dollar(5).Equals(Money.dollar(5)));
        Assert.False(Money.dollar(5).Equals(Money.dollar(6)));
        Assert.True(new Franc(5, "CHF").Equals(new Franc(5, "CHF")));
        Assert.False(new Franc(5, "CHF").Equals(new Franc(6, "CHF")));
        Assert.False(Money.dollar(5).Equals(new Franc(5, "CHF")));
    }

    [Fact]
    public void testFrancMultiplication()
    {
        var five = Money.franc(5);
        five.times(2).Should().Be(new Franc(10, "CHF"));
        Assert.Equal(new Franc(10, "CHF"), five.times(2));

        five.times(3).Should().Be(new Franc(15, "CHF"));
        Assert.Equal(new Franc(15, "CHF"), five.times(3));
    }

    [Fact]
    public void testCurrency()
    {
        Money.dollar(1).currency().Should().Be("USD");
        Money.franc(1).currency().Should().Be("CHF");
    }
}