namespace MyApp.Tests;

public class Dollar
{
    public int Amount { get; set; }

    public Dollar(int amount)
    {
        Amount = amount;
    }

    public void times(int mutiliplier)
    {
        Amount *= mutiliplier;
    }
}