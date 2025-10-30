using MyApp.Core;

namespace MyApp.Tests;

public class Sum(Expression augend, Expression addend) : Expression
{
    public Expression Augend => augend;
    public Expression Addend => addend;

    public Money reduce(Bank bank, string toCurrency)
    {
        var amount = Augend.reduce(bank, toCurrency).Amount +
                     Addend.reduce(bank, toCurrency).Amount;
        return new Money(amount, toCurrency);
    }

    public Expression plus(Expression addend)
    {
        return new Sum(this, addend);
    }

    public Expression times(int multiplier)
    {
        return new Sum(Augend.times(multiplier), Addend.times(multiplier));
    }
}