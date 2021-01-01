using Newtonsoft.Json;

namespace EliteAPI.Status.Ship
{
    /// <summary>
    /// Container class for information about the ship's fuel situation
    /// </summary>
    public class ShipFuel
    {
        internal ShipFuel()
        {
        }

        /// <summary>
        /// The ship's current amount of fuel left in the main fuel tank 
        /// </summary>
        [JsonProperty("FuelMain")]
        public float Main { get; init; }

        /// <summary>
        /// The ship's current amount of fuel left in the reservoir fuel tank 
        /// </summary>
        [JsonProperty("FuelReservoir")]
        public float Reservoir { get; init; }
    }
}