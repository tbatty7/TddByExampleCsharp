using MyApp.Core;

namespace MyApp.Tests;

public class Franc : Money
{
    public Franc(int amount)
    {
        Amount = amount;
    }

    public Franc times(int multiplier)
    {
        return new Franc(Amount * multiplier);
    }
}