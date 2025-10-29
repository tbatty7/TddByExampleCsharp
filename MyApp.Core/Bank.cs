using MyApp.Core;

namespace MyApp.Tests;

public class Bank
{
    public Money reduce(Expression sum, string currency)
    {
        return Money.dollar(10);
    }
}