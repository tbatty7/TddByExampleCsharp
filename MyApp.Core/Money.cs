namespace MyApp.Core;

public class Money : Expression
{
    public int Amount { get; }
    private string Currency { get; }

    public Money(int amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public override bool Equals(Object other)
    {
        Money? money = other as Money;
        return Amount == money.Amount && currency().Equals(money.currency());
    }

    public static Money dollar(int amount)
    {
        return new Money(amount, "USD");
    }

    public static Money franc(int amount)
    {
        return new Money(amount, "CHF");
    }

    public Expression times(int multiplier)
    {
        return new Money(Amount * multiplier, Currency);
    }

    public string currency()
    {
        return Currency;
    }

    public override string ToString()
    {
        return $"{Amount} {Currency}";
    }

    public Expression plus(Expression addend)
    {
        return new Sum(this, addend);
    }

    public Money reduce(Bank bank, string toCurrency)
    {
        var rate = bank.rate(Currency, toCurrency);
        return new Money(Amount / rate, toCurrency);
    }
}