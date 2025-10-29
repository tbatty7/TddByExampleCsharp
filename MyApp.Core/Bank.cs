using MyApp.Core;

namespace MyApp.Tests;

public class Bank
{
    public Money reduce(Expression source, string toCurrency)
    {
        return source.reduce(toCurrency);
    }
}