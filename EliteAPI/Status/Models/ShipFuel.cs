using Newtonsoft.Json;

namespace EliteAPI.Status.Models
{
    /// <summary>
    /// Container for information about the ship's fuel situation
    /// </summary>
    public class ShipFuel
    {
        internal ShipFuel() { }

        /// <summary>
        /// The amount of fuel left in the main tank, in tonnes
        /// </summary>
        [JsonProperty("FuelMain")]
        public float Main { get; private set; }

        /// <summary>
        /// The amount of fuel left in the reservoir tank, in tonnes
        /// </summary>
        [JsonProperty("FuelReservoir")]
        public float Reservoir { get; private set; }
    }
}