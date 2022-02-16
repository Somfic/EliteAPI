using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Events.Status.NavRoute;

public readonly struct NavRouteStop
{
    /// <summary>
    /// The name of the star system
    /// </summary>
    [JsonProperty("StarSystem")]
    public string System { get; init; }

    /// <summary>
    /// The address of the star system
    /// </summary>
    [JsonProperty("SystemAddress")]
    public string Address { get; init; }

    /// <summary>
    /// The position of the star system
    /// </summary>
    [JsonProperty("StarPos")]
    public IReadOnlyList<double> Position { get; init; }

    /// <summary>
    /// The class of the star system's main star
    /// </summary>
    [JsonProperty("StarClass")]
    [JsonConverter(typeof(StringEnumConverter))]
    public StarClass Class { get; init; }
}