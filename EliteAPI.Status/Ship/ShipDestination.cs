using Newtonsoft.Json;

namespace EliteAPI.Status.Ship;

public readonly struct ShipDestination
{
    [JsonProperty("System")]
    public string SystemId { get; init; }
        
    [JsonProperty("Body")]
    public string BodyId { get; init; }
          
    [JsonProperty("Name")]
    public string Name { get; init; }
}