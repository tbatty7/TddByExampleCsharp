namespace MyApp.Core.Learning;

public class LargerStructures
{
    public string TryGetValue(Dictionary<string, string> dictionary, string key)
    {
        if (dictionary.TryGetValue("key", out var value)) return value;

        return "Not found";
    }
}