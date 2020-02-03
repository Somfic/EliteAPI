using EliteAPI.Status;
using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// This event is written when the game has started.
    /// </summary>
    /// <seealso cref="ProgressInfo"/>
    public class RankInfo : EventBase
    {
        internal RankInfo() { }
       
        /// <summary>
        /// The rank within Combat the commander has.
        /// Returns a scale from 0-8.
        /// </summary>
        [JsonProperty("Combat")]
        public long Combat { get; internal set; }

        /// <summary>
        /// The rank within Combat the commander has.
        /// Returns the localised title.
        /// </summary>
        public string CombatLocalised => RankUtil.Combat(Combat);

        /// <summary>
        /// The rank within Trade the commander has.
        /// Returns a scale from 0-8.
        /// </summary>
        [JsonProperty("Trade")]
        public long Trade { get; internal set; }

        /// <summary>
        /// The rank within Trade the commander has.
        /// Returns the localised title.
        /// </summary>
        public string TradeLocalised => RankUtil.Trade(Trade);

        /// <summary>
        /// The rank within Exploration the commander has.
        /// Returns a scale from 0-8.
        /// </summary>
        [JsonProperty("Explore")]
        public long Exploration { get; internal set; }

        /// <summary>
        /// The rank within Explore the commander has.
        /// Returns the localised title.
        /// </summary>
        public string ExplorationLocalised => RankUtil.Exploration(Exploration);

        /// <summary>
        /// The rank within the Empire the commander has.
        /// Returns a scale from 0-14.
        /// </summary>
        [JsonProperty("Empire")]
        public long Empire { get; internal set; }

        /// <summary>
        /// The rank within the Empire the commander has.
        /// Returns the localised title.
        /// </summary>
        public string EmpireLocalised => RankUtil.Empire(Empire);

        /// <summary>
        /// The rank within the Federation the commander has.
        /// Returns a scale from 0-14.
        /// </summary>
        [JsonProperty("Federation")]
        public long Federation { get; internal set; }

        /// <summary>
        /// The rank within the Federation the commander has.
        /// Returns the localised title.
        /// </summary>
        public string FederationLocalised => RankUtil.Empire(Federation);

        /// <summary>
        /// The rank within the Federation the commander has.
        /// Returns a scale from 0-8.
        /// </summary>
        [JsonProperty("CQC")]
        public long Cqc { get; internal set; }

        internal static RankInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeRankEvent(JsonConvert.DeserializeObject<RankInfo>(json, JsonSettings.Settings));
        }
    }
}