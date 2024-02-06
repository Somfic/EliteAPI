using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct LoadGameEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("FID")]
    public string Fid { get; init; }

    [JsonProperty("Commander")]
    public string Commander { get; init; }

    [JsonProperty("Horizons")]
    public bool HasHorizons { get; init; }

    [JsonProperty("Odyssey")]
    public bool HasOdyssey { get; init; }

    [JsonProperty("Ship")]
    public Localised Ship { get; init; }

    [JsonProperty("ShipID")]
    public string ShipId { get; init; }

    [JsonProperty("ShipName")]
    public string ShipName { get; init; }

    [JsonProperty("ShipIdent")]
    public string ShipIdent { get; init; }

    [JsonProperty("FuelLevel")]
    public double FuelLevel { get; init; }

    [JsonProperty("FuelCapacity")]
    public double FuelCapacity { get; init; }

    [JsonProperty("StartLanded")]
    public bool IsLanded { get; init; }

    [JsonProperty("GameMode")]
    public string GameMode { get; init; }

    [JsonProperty("language")]
    public string Language { get; init; }

    [JsonProperty("gameversion")]
    public string GameVersion { get; init; }

    [JsonProperty("build")]
    public string Build { get; init; }

    [JsonProperty("Credits")]
    public long Credits { get; init; }

    [JsonProperty("Loan")]
    public long Loan { get; init; }
}