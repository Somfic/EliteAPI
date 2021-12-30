using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct CargoEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Vessel")]
    public string Vessel { get; init; }

    [JsonProperty("Count")]
    public long Count { get; init; }

    [JsonProperty("Inventory")]
    public IReadOnlyCollection<CargoInfo> Inventory { get; init; }


    public readonly struct CargoInfo
    {
        [JsonProperty("Name")]
        public Localised Name { get; init; }

        [JsonProperty("Count")]
        public int Count { get; init; }

        [JsonProperty("Stolen")]
        public bool IsStolen { get; init; }

        [JsonProperty("MissionID")]
        public string MissionId { get; init; }
    }
}