namespace EliteAPI.Abstractions.Bindings.Models;

public struct ToggleSubBinding : ISubBinding
{
    public ToggleSubBinding(bool value)
    {
        Value = value;
    }

    public bool Value { get; init; }
}