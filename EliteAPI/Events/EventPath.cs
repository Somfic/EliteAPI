
using System;
using System.Runtime.CompilerServices;

namespace EliteAPI.Events;

public readonly struct EventPath(string path, dynamic value, EventValueType type)
{
    public string Path { get; init; } = path;

    public dynamic Value { get; init; } = value;

    public EventValueType Type { get; init; } = type;

    internal EventPath WithPath(string path) => new(path.Replace("..", "."), Value, Type);
}

public enum EventValueType
{
    String,
    Number,
    Decimal,
    Boolean,
    DateTime,
}


public static class EventUtils
{
    public static string ToDisplayType(this EventValueType valueType) => valueType switch
    {
        EventValueType.String => "TXT",
        EventValueType.Number => "INT",
        EventValueType.Decimal => "DEC",
        EventValueType.Boolean => "BOOL",
        EventValueType.DateTime => "DATE",
        _ => "",
    };
}
