using MyApp.Core;

namespace MyApp.Tests;

public class Dollar : Money
{
    public Dollar(int amount)
    {
        Amount = amount;
    }

    public override Money times(int multiplier)
    {
        return new Dollar(Amount * multiplier);
    }
}