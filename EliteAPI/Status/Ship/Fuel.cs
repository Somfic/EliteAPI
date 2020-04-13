using Newtonsoft.Json;

namespace EliteAPI.Status.Ship
{
    public class Fuel
    {
        internal Fuel() { }

        [JsonProperty("FuelMain")]
        public long FuelMain { get; internal set; }

        [JsonProperty("FuelReservoir")]
        public double FuelReservoir { get; internal set; }
    }
}