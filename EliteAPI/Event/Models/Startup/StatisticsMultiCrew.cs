using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Startup
{
    /// <summary>
    /// Contains statistics on the commander's multicrew.
    /// </summary>
    /// <see cref="StatisticsInfo"/>
    public class StatisticsMultiCrew
    {
        internal StatisticsMultiCrew() { }

        /// <summary>
        /// The total amount of seconds spent in multicrew.
        /// </summary>
        [JsonProperty("Multicrew_Time_Total")]
        public int TimeTotal { get; internal set; }

        /// <summary>
        /// The total amount of seconds spent as a multicrew gunner.
        /// </summary>
        [JsonProperty("Multicrew_Gunner_Time_Total")]
        public int GunnerTimeTotal { get; internal set; }

        /// <summary>
        /// The total amount of seconds spent in a multicrew fighter.
        /// </summary>
        [JsonProperty("Multicrew_Fighter_Time_Total")]
        public int FighterTimeTotal { get; internal set; }

        /// <summary>
        /// The total amount of profit made.
        /// </summary>
        [JsonProperty("Multicrew_Credits_Total")]
        public long CreditsTotal { get; internal set; }

        /// <summary>
        /// The total amount of fines.
        /// </summary>
        [JsonProperty("Multicrew_Fines_Total")]
        public long FinesTotal { get; internal set; }
    }
}