namespace EliteAPI.Bindings;

public struct InvertedSubBinding : ISubBinding
{
    public InvertedSubBinding(bool value)
    {
        Value = value;
    }
    
    public bool Value { get; init; }
}