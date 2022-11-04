namespace EliteAPI.Abstractions.Bindings.Models;

public struct Binding
{
    public string Name { get; init; }

    public PrimarySubBinding? Primary { get; init; }
    
    public SecondarySubBinding? Secondary { get; init; }
    
    public bool? IsToggle { get; init; }
    
    public bool? IsInverted { get; init; }
    
    public float? Deadzone { get; init; }
}