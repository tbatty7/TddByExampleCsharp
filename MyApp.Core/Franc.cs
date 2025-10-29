namespace MyApp.Tests;

public class Franc
{
    public int Amount { get; init; }

    public Franc(int amount)
    {
        Amount = amount;
    }

    public Franc times(int multiplier)
    {
        return new Franc(Amount * multiplier);
    }

    public override bool Equals(Object other)
    {
        Franc? otherFranc = other as Franc;
        return Amount == otherFranc.Amount;
    }
}