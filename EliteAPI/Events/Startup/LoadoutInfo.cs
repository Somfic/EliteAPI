using Newtonsoft.Json;
using System.Collections.Generic;
using EliteAPI.Status;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// This event is written when the game has started, after switching ships, after outfitting, and after docking a SRV.
    /// </summary>
    public class LoadoutInfo : EventBase
    {
        internal LoadoutInfo() { }

        /// <summary>
        /// The type of ship.
        /// </summary>
        [JsonProperty("Ship")]
        //[JsonConverter(typeof(StringEnumConverter))]
        public string Ship { get; internal set; }

        /// <summary>
        /// The id of the ship.
        /// </summary>
        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        /// <summary>
        /// The user-defined name of the ship.
        /// </summary>

        [JsonProperty("ShipName")]
        public string ShipName { get; internal set; }

        /// <summary>
        /// The user-defined id of the ship.
        /// </summary>
        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; internal set; }

        /// <summary>
        /// The value of the integrity of the hull.
        /// </summary>
        [JsonProperty("HullValue")]
        public long HullValue { get; internal set; }

        /// <summary>
        /// The value of the integrity of the modules.
        /// </summary>
        [JsonProperty("ModulesValue")]
        public long ModulesValue { get; internal set; }

        /// <summary>
        /// The health of the hull.
        /// </summary>
        [JsonProperty("HullHealth")]
        public float HullHealth { get; internal set; }

        /// <summary>
        /// The mass of the hull and all modules. Fuel and cargo are not included.
        /// </summary>
        [JsonProperty("UnladenMass")]
        public int UnladenMass { get; internal set; }

        /// <summary>
        /// Information on the fuel of the ship.
        /// </summary>
        /// <see cref="FuelInfo"/>
        [JsonProperty("FuelCapacity")]
        public FuelInfo FuelCapacity { get; internal set; }

        /// <summary>
        /// The maximum amount of cargo this ship can carry.
        /// </summary>
        [JsonProperty("CargoCapacity")]
        public int CargoCapacity { get; internal set; }

        /// <summary>
        /// The maximum jump range of the ship.
        /// </summary>
        /// <remarks>
        /// This value is based on no cargo and limited fuel.
        /// </remarks>
        [JsonProperty("MaxJumpRange")]
        public float MaxJumpRange { get; internal set; }

        /// <summary>
        /// The cost of rebuy.
        /// </summary>
        [JsonProperty("Rebuy")]
        public long Rebuy { get; internal set; }

        /// <summary>
        /// Whether the ship is wanted.
        /// </summary>
        [JsonProperty("Hot")]
        public bool Hot { get; internal set; }

        /// <summary>
        /// A list of installed items on the ship.
        /// </summary>
        /// <see cref="ModuleInfo"/>
        [JsonProperty("Modules")]
        public IReadOnlyList<ModuleInfo> Modules { get; internal set; }

        internal static LoadoutInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeLoadoutEvent(JsonConvert.DeserializeObject<LoadoutInfo>(json, JsonSettings.Settings));
        }
    }
}