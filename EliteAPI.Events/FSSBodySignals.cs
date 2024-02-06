using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct FssBodySignalsEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("BodyName")]
    public string BodyName { get; init; }
    
    [JsonProperty("BodyID")]
    public string BodyId { get; init; }
    
    [JsonProperty("Signals")]
    public IReadOnlyCollection<SignalInfo> Signals { get; init; }
    
    [JsonProperty("SystemName")]
    public string SystemName { get; init; }

    public readonly struct SignalInfo
    {
        [JsonProperty("Type")]
        public string Type { get; init; }
        
        [JsonProperty("Count")]
        public long Count { get; init; }
    }
}