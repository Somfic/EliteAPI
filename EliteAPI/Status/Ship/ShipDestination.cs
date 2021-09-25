using Newtonsoft.Json;

namespace EliteAPI.Status.Ship
{
    /// <summary>
    /// Container class for information about the ship's destination
    /// </summary>
    public class ShipDestination
    {
        internal ShipDestination() { }
        
        [JsonProperty("System")]
        public string SystemId { get; init; }
        
        [JsonProperty("Body")]
        public string BodyId { get; init; }
          
        [JsonProperty("Name")]
        public string Name { get; init; }
    }
}