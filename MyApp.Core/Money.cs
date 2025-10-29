using MyApp.Tests;

namespace MyApp.Core;

public abstract class Money
{
    protected int Amount { get; init; }
    protected string Currency { get; init; }

    public Money(int amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public override bool Equals(Object other)
    {
        Money? money = other as Money;
        return Amount == money.Amount && GetType() == money.GetType();
    }

    public static Money dollar(int amount)
    {
        return new Dollar(amount, "USD");
    }

    public static Money franc(int amount)
    {
        return new Franc(amount, "CHF");
    }

    public abstract Money times(int multiplier);

    public string currency()
    {
        return Currency;
    }
}