using MyApp.Tests;

namespace MyApp.Core;

public abstract class Money
{
    protected int Amount { get; init; }


    public override bool Equals(Object other)
    {
        Money? money = other as Money;
        return Amount == money.Amount && GetType() == money.GetType();
    }

    public static Money dollar(int amount)
    {
        return new Dollar(amount);
    }

    public abstract Money times(int multiplier);

    public static Money franc(int amount)
    {
        return new Franc(amount);
    }
}