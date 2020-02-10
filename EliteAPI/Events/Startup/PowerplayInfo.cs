using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// This event is written when the game has started.
    /// Only triggered when the commander has pledged themselves to a galactic power.
    /// </summary>
    public class PowerplayInfo : EventBase
    {
        internal PowerplayInfo() { }

        /// <summary>
        /// The name of the galactic power.
        /// </summary>
        [JsonProperty("Power")]
        public string Power { get; internal set; }

        /// <summary>
        /// The rank of the commander within the power.
        /// </summary>
        [JsonProperty("Rank")]
        public int Rank { get; internal set; }

        /// <summary>
        /// The amount of merits the commander has.
        /// </summary>
        [JsonProperty("Merits")]
        public int Merits { get; internal set; }

        /// <summary>
        /// The amount of votes the commander has.
        /// </summary>
        [JsonProperty("Votes")]
        public int Votes { get; internal set; }

        /// <summary>
        /// The amount of seconds the commander has been pledged to this power.
        /// </summary>
        [JsonProperty("TimePledged")]
        public long TimePledged { get; internal set; }

        internal static PowerplayInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokePowerplayEvent(JsonConvert.DeserializeObject<PowerplayInfo>(json, JsonSettings.Settings));
        }
    }
}