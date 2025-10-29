namespace MyApp.Core;

public interface Expression
{
    Money reduce(string toCurrency);
}