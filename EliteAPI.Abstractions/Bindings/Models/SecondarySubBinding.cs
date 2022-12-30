namespace EliteAPI.Abstractions.Bindings.Models;

public struct SecondarySubBinding : ISubBinding
{
    public SecondarySubBinding((string key, string device, ModifierBinding[] modifiers) binding)
    {
        Device = binding.device;
        Key = binding.key;
        Modifiers = binding.modifiers;
    }
    
    public string Device { get; init; }
    
    public string Key { get; init; }
    
    public ModifierBinding[] Modifiers { get; init; }
}