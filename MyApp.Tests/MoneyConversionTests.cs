using FluentAssertions;

namespace MyApp.Tests;

public class MoneyConversionTests
{
    [Fact]
    public void testMultiplication()
    {
        Dollar five = new Dollar(5);
        five.times(2).Should().Be(new Dollar(10));
        Assert.Equal(new Dollar(10), five.times(2));

        five.times(3).Should().Be(new Dollar(15));
        Assert.Equal(new Dollar(15), five.times(3));
    }

    [Fact]
    public void testEquality()
    {
        Assert.True(new Dollar(5).Equals(new Dollar(5)));
        Assert.False(new Dollar(5).Equals(new Dollar(6)));
        Assert.True(new Franc(5).Equals(new Franc(5)));
        Assert.False(new Franc(5).Equals(new Franc(6)));
        Assert.False(new Dollar(5).Equals(new Franc(5)));
    }

    [Fact]
    public void testFrancMultiplication()
    {
        Franc five = new Franc(5);
        five.times(2).Should().Be(new Franc(10));
        Assert.Equal(new Franc(10), five.times(2));

        five.times(3).Should().Be(new Franc(15));
        Assert.Equal(new Franc(15), five.times(3));
    }
}