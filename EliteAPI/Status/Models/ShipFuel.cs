using Newtonsoft.Json;

namespace EliteAPI.Status.Models
{
    public class ShipFuel
    {
        [JsonProperty("FuelMain")]
        public float Main { get; private set; }

        [JsonProperty("FuelReservoir")]
        public float Reservoir { get; private set; }
    }
}