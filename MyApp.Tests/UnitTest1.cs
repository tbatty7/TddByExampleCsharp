using FluentAssertions;

namespace MyApp.Tests;

public class UnitTest1
{
    [Fact]
    public void canAdd()
    {
        var result = 1 + 1;
        result.Should().Be(2);
    }
}