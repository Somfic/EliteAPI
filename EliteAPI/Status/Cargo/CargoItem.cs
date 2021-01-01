using Newtonsoft.Json;

namespace EliteAPI.Status.Cargo
{
    /// <summary>
    /// Container class for an item in the ship's cargo
    /// </summary>
    public class CargoItem
    {
        /// <summary>
        /// The name of the item
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The localised name of the item
        /// </summary>
        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; set; }

        /// <summary>
        /// The amount of tonnes of this item in the ship's cargo
        /// </summary>
        [JsonProperty("Count")]
        public int Count { get; set; }

        /// <summary>
        /// The amount of tonnes of this item in the ship's cargo that are stolen
        /// </summary>
        [JsonProperty("Stolen")]
        public int Stolen { get; set; }
    }
}