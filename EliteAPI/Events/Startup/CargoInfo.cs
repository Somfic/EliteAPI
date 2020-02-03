using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// This event is written when the game has started.
    /// </summary>
    public class CargoInfo : EventBase
    {
        internal CargoInfo() { }

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
        /// <see cref="InventoryInfo"/>
        [JsonProperty("Inventory")]
        public IReadOnlyList<InventoryInfo> Inventory { get; internal set; }

        internal static CargoInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeCargoEvent(JsonConvert.DeserializeObject<CargoInfo>(json, JsonSettings.Settings));
        }
    }

    /// <summary>
    /// The type of vessel, either 'Ship' or 'SRV'.
    /// </summary>
    /// <see cref="CargoInfo"/>
    public enum VesselType { Ship, SRV }

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