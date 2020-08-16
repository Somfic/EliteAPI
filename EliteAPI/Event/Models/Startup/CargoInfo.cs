using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Event.Models.Startup
{
    /// <summary>
    /// This event is written when the game has started.
    /// </summary>
    public class CargoEvent : EventBase
    {
        internal CargoEvent() { }

        public static CargoEvent FromJson(string json) => JsonConvert.DeserializeObject<CargoEvent>(json);



        /// <summary>
        /// The type of vessel, either 'Ship' or 'SRV'.
        /// </summary>
        /// <see cref="VesselType"/>
        [JsonProperty("Vessel")]
        [JsonConverter(typeof(StringEnumConverter))]
        public VesselType Vessel { get; internal set; }

        /// <summary>
        /// The total amount of cargo in the vessel.
        /// </summary>
        [JsonProperty("Count")]
        public int Count { get; internal set; }

        /// <summary>
        /// A list of all inventory in the vessel, grouped by name.
        /// </summary>
        /// <see cref="CargoInventory"/>
        [JsonProperty("Inventory")]
        public IReadOnlyList<CargoInventory> Inventory { get; internal set; }

        
    }
}