using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct DatalinkVoucherEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Reward")]
    public long Reward { get; init; }

    [JsonProperty("VictimFaction")]
    public string VictimFaction { get; init; }

    [JsonProperty("PayeeFaction")]
    public string PayeeFaction { get; init; }
}