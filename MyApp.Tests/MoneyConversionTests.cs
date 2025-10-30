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
        Assert.False(Money.dollar(5).Equals(Money.franc(5)));
    }

    [Fact]
    public void testCurrency()
    {
        Money.dollar(1).currency().Should().Be("USD");
        Money.franc(1).currency().Should().Be("CHF");
    }

    [Fact]
    public void testSimpleAddition()
    {
        var sum = Money.dollar(5).plus(Money.dollar(5));
        var bank = new Bank();
        var reduced = bank.reduce(sum, "USD");
        reduced.Should().Be(Money.dollar(10));
    }

    [Fact]
    public void testPlusReturnsSum()
    {
        var five = Money.dollar(5);
        var result = five.plus(five);
        var sum = (Sum)result;
        Assert.Equal(five, sum.Augend);
        Assert.Equal(five, sum.Addend);
    }

    [Fact]
    public void testReduceSum()
    {
        Expression sum = new Sum(Money.dollar(3), Money.dollar(4));
        var bank = new Bank();
        var result = bank.reduce(sum, "USD");
        Assert.Equal(Money.dollar(7), result);
    }

    [Fact]
    public void testReduceMoney()
    {
        var dollar = Money.dollar(1);
        var bank = new Bank();
        var result = bank.reduce(dollar, "USD");
        Assert.Equal(dollar, result);
    }

    [Fact]
    public void testReduceMoneyDifferentCurrency()
    {
        var bank = new Bank();
        bank.addRate("CHF", "USD", 2);
        var result = bank.reduce(Money.franc(2), "USD");
        Assert.Equal(Money.dollar(1), result);
    }

    [Fact]
    public void testIdentityRate()
    {
        Assert.Equal(1, new Bank().rate("USD", "USD"));
    }

    [Fact]
    public void testMixedAddition()
    {
        Expression fiveBucks = Money.dollar(5);
        Expression tenFrancs = Money.franc(10);
        var bank = new Bank();
        bank.addRate("CHF", "USD", 2);
        var result = bank.reduce(fiveBucks.plus(tenFrancs), "USD");
        Assert.Equal(Money.dollar(10), result);
    }
}