namespace MyApp.Core;

public sealed class SharedRandom : IRandom
{
    public int Next(int max)
    {
        return Random.Shared.Next(max);
    }

    public int Next(int min, int max)
    {
        return Random.Shared.Next(min, max);
    }
}