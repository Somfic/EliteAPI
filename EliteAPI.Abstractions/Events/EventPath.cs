namespace EliteAPI.Abstractions.Events;

public readonly struct EventPath
{
    public EventPath(string path, string value)
    {
        Path = path;
        Value = value;
    }
    
   public string Path { get; init; }

   public string Value { get; init; }
}