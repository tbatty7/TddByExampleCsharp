using MyApp.Core;

namespace MyApp.Tests;

public class Franc : Money
{
    public Franc(int amount, string currency) : base(amount, currency)
    {
    }

    public override Money times(int multiplier)
    {
        return franc(Amount * multiplier);
    }
}