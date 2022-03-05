using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ReservoirReplenishedEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("FuelMain")]
    public double FuelMain { get; init; }

    [JsonProperty("FuelReservoir")]
    public double FuelReservoir { get; init; }
}