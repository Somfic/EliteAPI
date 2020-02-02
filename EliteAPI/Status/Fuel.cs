using Newtonsoft.Json;

namespace EliteAPI.Status
{
    public partial class Fuel
    {
        [JsonProperty("FuelMain")]
        public double FuelMain { get; internal set; }
        [JsonProperty("FuelReservoir")]
        public double FuelReservoir { get; internal set; }
        public double MaxFuel { get; internal set; }
    }
}