namespace MyApp.Tests;

public class Dollar
{
    public int Amount { get; init; }

    public Dollar(int amount)
    {
        Amount = amount;
    }

    public Dollar times(int multiplier)
    {
        return new Dollar(Amount * multiplier);
    }

    public bool Equals(Object other)
    {
        Dollar? otherDollar = other as Dollar;
        return Amount == otherDollar.Amount;
    }
}