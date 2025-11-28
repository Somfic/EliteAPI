
namespace EliteAPI.Events;

public readonly struct EventPath(string path, dynamic value, ValueType type)
{
    public string Path { get; init; } = path;

    public dynamic Value { get; init; } = value;

    public ValueType Type { get; init; } = type;

    internal EventPath WithPath(string path) => new(path.Replace("..", "."), Value, Type);
}

public enum ValueType
{
    String,
    Number,
    Decimal,
    Boolean,
    DateTime,
}
