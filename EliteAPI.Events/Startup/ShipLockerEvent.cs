using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ShipLockerEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Items")]
    public IReadOnlyCollection<ShipLockerMaterialInfo> Items { get; init; }

    [JsonProperty("Components")]
    public IReadOnlyCollection<ShipLockerMaterialInfo> Components { get; init; }

    [JsonProperty("Consumables")]
    public IReadOnlyCollection<ShipLockerMaterialInfo> Consumables { get; init; }

    [JsonProperty("Data")]
    public IReadOnlyCollection<ShipLockerMaterialInfo> Data { get; init; }


    public readonly struct ShipLockerMaterialInfo
    {
        [JsonProperty("Name")]
        public string Name { get; init; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; init; }

        [JsonProperty("OwnerID")]
        public string OwnerId { get; init; }

        [JsonProperty("Count")]
        public long Count { get; init; }
    }
}