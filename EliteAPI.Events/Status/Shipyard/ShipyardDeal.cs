using Newtonsoft.Json;

namespace EliteAPI.Events.Status.Shipyard;

public readonly struct ShipyardDeal
{
    [JsonProperty("id")]
    public string Id { get; init; }

    [JsonProperty("ShipType")]
    public string ShipType { get; init; }

    [JsonProperty("ShipPrice")]
    public long ShipPrice { get; init; }

    [JsonProperty("ShipType_Localised")]
    public string ShipTypeLocalised { get; init; }
}