using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct SupercruiseExitEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("StarSystem")]
    public string StarSystem { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }

    [JsonProperty("Taxi")]
    public bool IsTaxi { get; init; }

    [JsonProperty("Multicrew")]
    public bool IsMulticrew { get; init; }

    [JsonProperty("Body")]
    public string Body { get; init; }

    [JsonProperty("BodyID")]
    public string BodyId { get; init; }

    [JsonProperty("BodyType")]
    public string BodyType { get; init; }
}