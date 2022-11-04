namespace EliteAPI.Abstractions.Bindings.Models;

public struct ModifierBinding
{
    public ModifierBinding(string key, string device)
    {
        Device = device;
        Key = key;
    }
    
    public string Device { get; init; }
    
    public string Key { get; init; }
}