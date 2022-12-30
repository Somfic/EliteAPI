namespace EliteAPI.Abstractions.Bindings.Models;

public struct Binding
{
    public string Name { get; init; }

    public SubBinding? Primary { get; init; }
    
    public SubBinding? Secondary { get; init; }
    
    public bool? IsToggle { get; init; }
    
    public bool? IsInverted { get; init; }
    
    public float? Deadzone { get; init; }
}