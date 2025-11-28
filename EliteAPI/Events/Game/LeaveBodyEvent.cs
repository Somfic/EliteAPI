using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct LeaveBodyEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("StarSystem")]
    public string StarSystem { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }

    [JsonProperty("Body")]
    public string Body { get; init; }

    [JsonProperty("BodyID")]
    public string BodyId { get; init; }
}
