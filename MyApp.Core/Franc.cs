using MyApp.Core;

namespace MyApp.Tests;

public class Franc : Money
{
    public Franc(int amount)
    {
        Amount = amount;
    }

    public override Money times(int multiplier)
    {
        return new Franc(Amount * multiplier);
    }
}