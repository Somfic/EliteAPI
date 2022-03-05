using EliteAPI.VoiceAttack.Proxy.Variables;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.VoiceAttack.Messages.Variables;

public struct Variable
{
    public Variable(string name, Types type, string value)
    {
        Name = name;
        Type = type;
        Value = value;
    }
        
    public string Name { get; }
    
    [JsonConverter(typeof(StringEnumConverter))]
    public Types Type { get; }
    public string Value { get; }
}