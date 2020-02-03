using Newtonsoft.Json;

namespace EliteAPI.Events.Startup {
    /// <summary>
    /// Inventory in the vessel, grouped by name.
    /// </summary>
    /// <see cref="CargoInfo"/>
    public class InventoryInfo
    {
        internal InventoryInfo() { }

        /// <summary>
        /// The name of the cargo item.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        /// <summary>
        /// The localised name of the cargo item.
        /// Returns null when the 'Name' property is already localised.
        /// </summary>
        [JsonProperty("Name_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string NameLocalised { get; internal set; }

        /// <summary>
        /// The amount of cargo of this type.
        /// </summary>
        [JsonProperty("Count")]
        public int Count { get; internal set; }

        /// <summary>
        /// The amount of stolen cargo of this type.
        /// </summary>
        [JsonProperty("Stolen")]
        public int Stolen { get; internal set; }
    }
}