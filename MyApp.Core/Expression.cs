using MyApp.Tests;

namespace MyApp.Core;

public interface Expression
{
    Money reduce(Bank bank, string toCurrency);
    Expression plus(Expression addend);
    Expression times(int multiplier);
}