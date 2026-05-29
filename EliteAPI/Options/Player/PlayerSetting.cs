namespace EliteAPI.Options.Player;

public readonly struct PlayerSetting
{
    public string Name { get; init; }

    public string Value { get; init; }

    public string ToDebugString() => $"{Name}={Value}";
}
