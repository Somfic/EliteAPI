using Newtonsoft.Json;

namespace EliteAPI.Status.Ship
{
    public class Fuel
    {
        [JsonProperty("FuelMain")]
        public float FuelMain { get; internal set; }
        [JsonProperty("FuelReservoir")]
        public float FuelReservoir { get; internal set; }
        public float MaxFuel { get; internal set; }
    }
}