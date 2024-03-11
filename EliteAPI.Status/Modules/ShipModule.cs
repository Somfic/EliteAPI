using Newtonsoft.Json;

namespace EliteAPI.Status.Modules;

public readonly struct ShipModule
{
    /// <summary>
    /// In which slot this module is located
    /// </summary>
    [JsonProperty("Slot")]
    public string Slot { get; init; }

    /// <summary>
    /// The module's name
    /// </summary>
    [JsonProperty("Item")]
    public string Name { get; init; }

    /// <summary>
    /// The factor of power this module has
    /// </summary>
    [JsonProperty("Power")]
    public double Power { get; init; }

    /// <summary>
    /// The priority of this module, if applicable
    /// </summary>
    [JsonProperty("Priority")]
    public int? Priority { get; init; }
}