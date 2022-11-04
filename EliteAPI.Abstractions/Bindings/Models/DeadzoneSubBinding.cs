namespace EliteAPI.Abstractions.Bindings.Models;

public struct DeadzoneSubBinding : ISubBinding
{
    public DeadzoneSubBinding(float value)
    {
        Value = value;
    }

    public float Value { get; init; }
}