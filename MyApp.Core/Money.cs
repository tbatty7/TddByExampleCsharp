namespace MyApp.Core;

public class Money
{
    protected int Amount { get; init; }


    public override bool Equals(Object other)
    {
        Money? money = other as Money;
        return Amount == money.Amount && GetType() == money.GetType();
    }
}