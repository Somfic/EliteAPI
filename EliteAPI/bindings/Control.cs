namespace EliteAPI.Bindings;

public readonly struct Control
{
    public string Name { get; init; }

    public Binding? Primary { get; init; }

    public Binding? Secondary { get; init; }

    public bool? IsToggle { get; init; }

    public bool? IsInverted { get; init; }

    public float? Deadzone { get; init; }
    
    public string KeyCode { get {
        if (Primary is { Device: "Keyboard" })
            return Primary.Value.KeyCode;
        
        if (Secondary is { Device: "Keyboard" })
            return Secondary.Value.KeyCode;
        
        return string.Empty;
    }}
}
