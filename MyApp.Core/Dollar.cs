using MyApp.Core;

namespace MyApp.Tests;

public class Dollar : Money
{
    public Dollar(int amount, string currency) : base(amount, currency)
    {
    }

    public override Money times(int multiplier)
    {
        return dollar(Amount * multiplier);
    }
}