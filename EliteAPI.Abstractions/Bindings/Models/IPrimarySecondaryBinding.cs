namespace EliteAPI.Abstractions.Bindings.Models;

public interface IPrimarySecondaryBinding : ISubBinding
{
    public string Device { get; init; }
    
    public string Key { get; init; }

    public ModifierBinding[] Modifiers { get; init; }
}