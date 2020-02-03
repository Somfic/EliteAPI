using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Events
{
    /// <summary>
    /// This event is written when the game has started.
    /// </summary>
    public class LoadGameInfo : EventBase
    {
        internal LoadGameInfo() { }

        /// <summary>
        /// The Frontier ID of the commander.
        /// </summary>
        [JsonProperty("FID")]
        public string Fid { get; internal set; }

        /// <summary>
        /// The name of the commander.
        /// </summary>
        [JsonProperty("Commander")]
        public string Commander { get; internal set; }

        /// <summary>
        /// Whether the commander has the Horizons expansion pack installed.
        /// </summary>
        [JsonProperty("Horizons")]
        public bool Horizons { get; internal set; }

        /// <summary>
        /// The current type of ship.
        /// </summary>
        [JsonProperty("Ship")]
        public string Ship { get; internal set; } //TODO: change to shiptype

        /// <summary>
        /// The localised type of the ship.
        /// </summary>
        [JsonProperty("Ship_Localised")]
        public string ShipLocalised { get; internal set; }

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
        /// Whether the commander is landed.
        /// </summary>
        [JsonProperty("StartLanded")]
        public bool StartLanded { get; internal set; }

        /// <summary>
        /// Whether the commander is dead.
        /// </summary>
        /// <seealso cref="ResurrectInfo"/>
        [JsonProperty("StartDead")]
        public bool StartDead { get; internal set; }

        /// <summary>
        /// The chosen game mode.
        /// </summary>
        [JsonProperty("GameMode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public GameModeType GameMode { get; internal set; }

        /// <summary>
        /// The name of the private group when playing in group mode.
        /// </summary>
        /// <see cref="GameMode"/>
        [JsonProperty("Group")]
        public string Group { get; internal set; }

        /// <summary>
        /// The amount of credits the commander has.
        /// </summary>
        [JsonProperty("Credits")]
        public long Credits { get; internal set; }

        /// <summary>
        /// The current loan.
        /// </summary>
        [JsonProperty("Loan")]
        public long Loan { get; internal set; }

        /// <summary>
        /// The current level of fuel.
        /// </summary>
        [JsonProperty("FuelLevel")]
        public float FuelLevel { get; internal set; }

        /// <summary>
        /// The size of the main fuel tank.
        /// </summary>
        [JsonProperty("FuelCapacity")]
        public float FuelCapacity { get; internal set; }

        internal static LoadGameInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeLoadGameEvent(JsonConvert.DeserializeObject<LoadGameInfo>(json, JsonSettings.Settings));
        }
    }
}