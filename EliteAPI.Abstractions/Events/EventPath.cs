using ProtoBuf;

namespace EliteAPI.Abstractions.Events;

[ProtoContract]
public readonly struct EventPath
{
    public EventPath(string path, string value)
    {
        Path = path;
        Value = value;
    }
    
   [ProtoMember(1)]
   public string Path { get; init; }

   [ProtoMember(2)]
   public string Value { get; init; }
}

[ProtoContract]
public readonly struct EventPaths
{
    public EventPaths(IEnumerable<EventPath> paths)
    {
        Paths = paths;
    }

    [ProtoMember(1)]
    public IEnumerable<EventPath> Paths { get; }
}
