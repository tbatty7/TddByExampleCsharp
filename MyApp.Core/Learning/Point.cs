namespace MyApp.Core.Learning;

// Use for Value Objects
public struct Point
{
    public int X;
    public int Y;

    // Custom constructor
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void DisplayCoordinates()
    {
        Console.WriteLine($"X: {X}, Y: {Y}");
    }
}