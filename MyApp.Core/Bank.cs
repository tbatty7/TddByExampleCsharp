using MyApp.Core;

namespace MyApp.Tests;

public class Bank
{
    private readonly Dictionary<Pair, int> rates = new();

    public Money reduce(Expression source, string toCurrency)
    {
        return source.reduce(this, toCurrency);
    }

    public void addRate(string from, string to, int rate)
    {
        rates.Add(new Pair(from, to), rate);
    }

    public int rate(string from, string to)
    {
        if (from == to) return 1;
        return rates[new Pair(from, to)];
    }
}