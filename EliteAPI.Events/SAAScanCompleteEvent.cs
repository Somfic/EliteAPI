using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct SaaScanCompleteEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("BodyName")]
    public string BodyName { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }

    [JsonProperty("BodyID")]
    public string BodyId { get; init; }

    [JsonProperty("ProbesUsed")]
    public long ProbesUsed { get; init; }

    [JsonProperty("EfficiencyTarget")]
    public long EfficiencyTarget { get; init; }
}