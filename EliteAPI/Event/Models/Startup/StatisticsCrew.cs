using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Startup
{
    /// <summary>
    /// Contains statistics on the commander's NPC crew.
    /// </summary>
    public class StatisticsCrew
    {
        internal StatisticsCrew() { }
        
        /// <summary>
        /// The total amount of wages spent on NPC crew.
        /// </summary>
        [JsonProperty("NpcCrew_TotalWages")]
        public long TotalWages { get; internal set; }

        /// <summary>
        /// The total amount of NPC crew hired.
        /// </summary>
        [JsonProperty("NpcCrew_Hired")]
        public int Hired { get; internal set; }

        /// <summary>
        /// The total amount of NPC crew fired.
        /// </summary>
        [JsonProperty("NpcCrew_Fired")]
        public int Fired { get; internal set; }

        /// <summary>
        /// The total amount of NPC crew that has died.
        /// </summary>
        [JsonProperty("NpcCrew_Died")]
        public int Died { get; internal set; }
    }
}