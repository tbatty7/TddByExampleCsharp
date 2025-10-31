namespace MyApp.Core.Learning;

public class StringStuff
{
    public string returnIfString(object obj)
    {
        if (obj is string s) return s;
        return "Not a string";
    }

    public string nullCheckName(string? maybeName)
    {
        if (maybeName is null) return "No name";
        return maybeName;
    }

    public string numberToString(int number)
    {
        return number switch
        {
            1 => "one",
            2 => "two",
            3 => "three",
            _ => "I'm tired, write out your own numbers..."
        };
    }
}