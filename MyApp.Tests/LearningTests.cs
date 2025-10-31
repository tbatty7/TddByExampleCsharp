using MyApp.Core.Learning;
using Xunit.Abstractions;

namespace MyApp.Tests;

public class LearningTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public LearningTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void StringInterpolation()
    {
        string name = "World";
        Assert.Equal("Hello World", $"Hello {name}");
    }

    [Fact]
    public void StructTest()
    {
        Point point = new Point(1, 2);
        Point point2 = new Point(1, 2);
        Assert.Equal(point, point2);
    }

    [Fact]
    public void ListCollections()
    {
        var nums = new List<int> { 1, 2, 3, 4, 5 };
        var evensEnumerable = nums.Where(n => n % 2 == 0).Select(n => n * 10);
        foreach (var i in evensEnumerable)
        {
            _testOutputHelper.WriteLine("Proper log: " + i);
            Console.WriteLine("You cannot see me!");
        }

        var evensList = evensEnumerable.ToList();
        foreach (var i in evensList) _testOutputHelper.WriteLine("Proper log: " + i);

        Assert.Equal(evensList, new List<int> { 20, 40 });
    }

    [Fact]
    public void PatternMatching()
    {
        var util = new StringStuff();
        Assert.Equal("Not a string", util.returnIfString(1));
        Assert.Equal("1", util.returnIfString("1"));
    }

    [Fact]
    public void RecordsAreDataClasses()
    {
        var dollarRecord = new DollarRecord(1);
        Assert.Equal(1, dollarRecord.amount);
    }

    [Fact]
    public void nullableTypes()
    {
        var util = new StringStuff();
        var result = util.nullCheckName(null);
        Assert.Equal("No name", result);

        var name = util.nullCheckName("Bob");
        Assert.Equal("Bob", name);
    }

    [Fact]
    public void switchExpressions()
    {
        var util = new StringStuff();
        Assert.Equal("one", util.numberToString(1));
        Assert.Equal("two", util.numberToString(2));
        Assert.Equal("three", util.numberToString(3));
        Assert.Equal("I'm tired, write out your own numbers...", util.numberToString(4));
    }
}