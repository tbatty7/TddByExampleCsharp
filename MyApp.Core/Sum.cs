using MyApp.Core;

namespace MyApp.Tests;

public class Sum(Money augend, Money addend) : Expression
{
    public Money Augend => augend;
    public Money Addend => addend;

    public Money reduce(string toCurrency)
    {
        var amount = Augend.Amount + Addend.Amount;
        return new Money(amount, toCurrency);
    }
}