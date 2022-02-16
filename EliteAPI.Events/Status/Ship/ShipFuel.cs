using Newtonsoft.Json;

namespace EliteAPI.Events.Status.Ship;

public readonly struct ShipFuel
{
    [JsonProperty("FuelMain")]
    public long FuelMain { get; init; }

    [JsonProperty("FuelReservoir")]
    public double FuelReservoir { get; init; }
}