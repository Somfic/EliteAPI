namespace EliteAPI.Options.Audio;

public readonly struct AudioSetting
{
    public string Name { get; init; }

    public float? Value { get; init; }

    public bool? IsMuted { get; init; }

    public bool? IsEnabled { get; init; }

    public bool IsVolume => Value.HasValue;

    public bool IsToggle => IsEnabled.HasValue;

    public string ToDebugString()
    {
        if (IsVolume)
        {
            var muted = IsMuted == true ? " (muted)" : string.Empty;
            return $"{Name}={Value:0.##}{muted}";
        }

        if (IsToggle)
            return $"{Name}={(IsEnabled == true ? "on" : "off")}";

        return Name;
    }
}
