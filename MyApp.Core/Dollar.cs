using MyApp.Core;

namespace MyApp.Tests;

public class Dollar : Money
{
    public Dollar(int amount)
    {
        Amount = amount;
    }

    public Dollar times(int multiplier)
    {
        return new Dollar(Amount * multiplier);
    }
}