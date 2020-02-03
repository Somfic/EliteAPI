using System.ComponentModel.DataAnnotations;
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
        [Range(0, 8)]
        public short Combat { get; internal set; }

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
        [Range(0, 8)]
        public short Trade { get; internal set; }

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
        [Range(0, 8)]
        public short Exploration { get; internal set; }

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
        [Range(0, 14)]
        public short Empire { get; internal set; }

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
        [Range(0, 14)]
        public short Federation { get; internal set; }

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
        [Range(0, 8)]
        public short Cqc { get; internal set; }

        internal static RankInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeRankEvent(JsonConvert.DeserializeObject<RankInfo>(json, JsonSettings.Settings));
        }
    }
}