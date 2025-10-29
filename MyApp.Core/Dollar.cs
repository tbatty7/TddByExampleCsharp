using MyApp.Core;

namespace MyApp.Tests;

public class Dollar : Money
{
    public Dollar(int amount, string currency) : base(amount, currency)
    {
    }
}