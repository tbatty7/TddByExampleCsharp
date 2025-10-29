namespace MyApp.Core;

public class Money : Expression
{
    private int Amount { get; }
    private string Currency { get; }

    private Money(int amount, string currency)
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

    public Money times(int multiplier)
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

    public Expression plus(Money addend)
    {
        return new Money(Amount + addend.Amount, Currency);
    }
}