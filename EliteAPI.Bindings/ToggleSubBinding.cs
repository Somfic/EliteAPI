namespace EliteAPI.Bindings;

public struct ToggleSubBinding : ISubBinding
{
    public ToggleSubBinding(bool value)
    {
        Value = value;
    }

    public bool Value { get; init; }
}