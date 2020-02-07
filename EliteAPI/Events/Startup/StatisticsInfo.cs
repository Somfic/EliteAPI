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
        /// <see cref="StatisticsBankAccountInfo"/>
        [JsonProperty("Bank_Account")]
        public StatisticsBankAccountInfo BankAccount { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's combat.
        /// </summary>
        /// <see cref="StatisticsCombatInfo"/>
        [JsonProperty("Combat")]
        public StatisticsCombatInfo Combat { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's crimes.
        /// </summary>
        /// <see cref="StatisticsCrimeInfo"/>
        [JsonProperty("Crime")]
        public StatisticsCrimeInfo StatisticsCrime { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's smuggling.
        /// </summary>
        /// <see cref="StatisticsSmugglingInfo"/>
        [JsonProperty("Smuggling")]
        public StatisticsSmugglingInfo Smuggling { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's trading.
        /// </summary>
        /// <see cref="StatisticsTradingInfo"/>
        [JsonProperty("Trading")]
        public StatisticsTradingInfo Trading { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's mining.
        /// </summary>
        /// <see cref="StatisticsMiningInfo"/>
        [JsonProperty("Mining")]
        public StatisticsMiningInfo Mining { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's exploration.
        /// </summary>
        /// <see cref="StatisticsExplorationInfo"/>
        [JsonProperty("Exploration")]
        public StatisticsExplorationInfo Exploration { get; internal set; }
        
        /// <summary>
        /// Contains statistics on the commander's passenger missions.
        /// </summary>
        /// <see cref="StatisticsPassengersInfo"/>
        [JsonProperty("Passengers")]
        public StatisticsPassengersInfo Passengers { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's search and rescue.
        /// </summary>
        /// <see cref="StatisticsSearchAndRescue"/>
        [JsonProperty("Search_And_Rescue")]
        public StatisticsSearchAndRescue SearchAndRescue { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's thargoid encounters.
        /// </summary>
        /// <see cref="StatisticsThargoidEncounters"/>
        [JsonProperty("TG_ENCOUNTERS")]
        public StatisticsThargoidEncounters ThargoidEncounters { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's crafting with engineers.
        /// </summary>
        /// <see cref="StatisticsCrafting"/>
        [JsonProperty("Crafting")]
        public StatisticsCrafting Crafting { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's NPC crew.
        /// </summary>
        /// <see cref="StatisticsCrew"/>
        [JsonProperty("Crew")]
        public StatisticsCrew Crew { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's multicrew.
        /// </summary>
        /// <see cref="StatisticsMultiCrew"/>
        [JsonProperty("Multicrew")]
        public StatisticsMultiCrew MultiCrew { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's material trades.
        /// </summary>
        /// <see cref="StatisticsMaterialTrader"/>
        [JsonProperty("Material_Trader_Stats")]
        public StatisticsMaterialTrader MaterialTrader { get; internal set; }

        internal static StatisticsInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeStatisticsEvent(JsonConvert.DeserializeObject<StatisticsInfo>(json, JsonSettings.Settings));
        }
    }
}