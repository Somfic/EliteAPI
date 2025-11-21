namespace EliteAPI;

public readonly struct JsonPath(string path, dynamic value, JsonType type)
{

    public string Path { get; init; } = path;

    public dynamic Value { get; init; } = value;

    public JsonType Type { get; init; } = type;


}

public enum JsonType
{
    String,
    Number,
    Decimal,
    Boolean,
    DateTime,
}
