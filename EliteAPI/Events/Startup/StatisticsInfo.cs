using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// This event is written when the game has started.
    /// </summary>
    public class StatisticsInfo : EventBase
    {
        internal StatisticsInfo() { }

        /// <summary>
        /// Contains statistics on the commander's bank account.
        /// </summary>
        /// <see cref="BankAccountInfo"/>
        [JsonProperty("Bank_Account")]
        public BankAccountInfo BankAccount { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's combat.
        /// </summary>
        /// <see cref="CombatInfo"/>
        [JsonProperty("Combat")]
        public CombatInfo Combat { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's crimes.
        /// </summary>
        /// <see cref="CrimeInfo"/>
        [JsonProperty("Crime")]
        public CrimeInfo Crime { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's smuggling.
        /// </summary>
        /// <see cref="SmugglingInfo"/>
        [JsonProperty("Smuggling")]
        public SmugglingInfo Smuggling { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's trading.
        /// </summary>
        /// <see cref="TradingInfo"/>
        [JsonProperty("Trading")]
        public TradingInfo Trading { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's mining.
        /// </summary>
        /// <see cref="MiningInfo"/>
        [JsonProperty("Mining")]
        public MiningInfo Mining { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's exploration.
        /// </summary>
        /// <see cref="ExplorationInfo"/>
        [JsonProperty("Exploration")]
        public ExplorationInfo Exploration { get; internal set; }
        
        //todo: continue this event

        internal static StatisticsInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeStatisticsEvent(JsonConvert.DeserializeObject<StatisticsInfo>(json, JsonSettings.Settings));
        }
    }
}