using MyApp.Tests;

namespace MyApp.Core;

public interface Expression
{
    Money reduce(Bank bank, string toCurrency);
}