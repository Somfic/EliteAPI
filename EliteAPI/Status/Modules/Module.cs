using Newtonsoft.Json;

namespace EliteAPI.Status.Modules
{
    /// <summary>
    /// Holds information about a module in the ship
    /// </summary>
    public class Module
    {
        internal Module() { }

        /// <summary>
        /// In which slot this module is located
        /// </summary>
        [JsonProperty("Slot")]
        public string Slot { get; init; }

        /// <summary>
        /// The module's name
        /// </summary>
        [JsonProperty("Item")]
        public string Name { get; init; }

        /// <summary>
        /// The factor of power this module has
        /// </summary>
        [JsonProperty("Power")]
        public double Power { get; init; }

        /// <summary>
        /// The priority of this module, if applicable
        /// </summary>
        [JsonProperty("Priority", NullValueHandling = NullValueHandling.Ignore)]
        public long? Priority { get; init; }
    }
}