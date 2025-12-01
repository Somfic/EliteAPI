using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct ApproachSettlementEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Name")]
    public string Name { get; init; }

    [JsonProperty("MarketID")]
    public string MarketId { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }

    [JsonProperty("BodyID")]
    public string BodyId { get; init; }

    [JsonProperty("BodyName")]
    public string BodyName { get; init; }

    [JsonProperty("Latitude")]
    public double Latitude { get; init; }

    [JsonProperty("Longitude")]
    public double Longitude { get; init; }

    [JsonProperty("StationGovernment")]
    public string StationGovernment { get; init; }

    [JsonProperty("StationAllegiance")]
    public string StationAllegiance { get; init; }

    [JsonProperty("StationEconomy")]
    public string StationEconomy { get; init; }
}
