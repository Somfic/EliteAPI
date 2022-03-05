namespace EliteAPI.VoiceAttack.Messages.Paths;

public struct EventPath
{
    public EventPath(string path, string value)
    {
        Path = path;
        Value = value;
    }
        
    public string Path { get; private set; }
        
    public string Value { get; private set; }
}