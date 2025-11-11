namespace MyApp.Core;

public interface IRandom
{
    int Next(int max);
    int Next(int min, int max);
}