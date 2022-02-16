using Newtonsoft.Json;

namespace EliteAPI.Events.Status;

public readonly struct ShipDestination
{
    [JsonProperty("System")]
    public string SystemId { get; init; }
        
    [JsonProperty("Body")]
    public string BodyId { get; init; }
          
    [JsonProperty("Name")]
    public string Name { get; init; }
}