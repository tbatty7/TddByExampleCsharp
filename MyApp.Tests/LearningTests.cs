using MyApp.Core.Learning;

namespace MyApp.Tests;

public class LearningTests
{
    [Fact]
    public void stringInterpolation()
    {
        string name = "World";
        Assert.Equal("Hello World", $"Hello {name}");
    }

    [Fact]
    public void structTest()
    {
        Point point = new Point(1, 2);
        Point point2 = new Point(1, 2);
        Assert.Equal(point, point2);
    }
    
    [Fact]
    public void listCollections()
    {
        
    }
}