namespace EliteAPI;

public struct JsonPath
{
    public string Path { get; init; }
    
    public dynamic Value { get; init; }
    
    public JsonType Type { get; init; }
}

public enum JsonType
{
    String,
    Number,
    Boolean
}