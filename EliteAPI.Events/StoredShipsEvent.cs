using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct StoredShipsEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("StationName")]
    public string StationName { get; init; }

    [JsonProperty("MarketID")]
    public string MarketId { get; init; }

    [JsonProperty("StarSystem")]
    public string StarSystem { get; init; }

    [JsonProperty("ShipsHere")]
    public IReadOnlyCollection<ShipsInfo> ShipsHere { get; init; }

    [JsonProperty("ShipsRemote")]
    public IReadOnlyCollection<ShipsInfo> ShipsRemote { get; init; }
    
    public readonly struct ShipsInfo
    {
        [JsonProperty("ShipID")]
        public long ShipId { get; init; }

        [JsonProperty("ShipType")]
        public Localised ShipType { get; init; }

        [JsonProperty("Value")]
        public long Value { get; init; }

        [JsonProperty("Hot")]
        public bool IsHot { get; init; }

        [JsonProperty("Name")]
        public string Name { get; init; }
    }
}