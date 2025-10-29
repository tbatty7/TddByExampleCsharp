namespace MyApp.Core;

public class Pair
{
    private readonly string From;
    private readonly string To;

    public Pair(string from, string to)
    {
        From = from;
        To = to;
    }

    public override bool Equals(object other)
    {
        var pair = (Pair)other;
        return pair.From.Equals(From) && pair.To.Equals(To);
    }

    public override int GetHashCode()
    {
        return From.GetHashCode() + To.GetHashCode();
    }
}