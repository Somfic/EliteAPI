using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Startup
{
    /// <summary>
    /// This event is written when the game has started.
    /// </summary>
    public class StatisticsEvent : EventBase
    {
        internal StatisticsEvent() { }

        /// <summary>
        /// Contains statistics on the commander's bank account.
        /// </summary>
        /// <see cref="StatisticsBankAccount"/>
        [JsonProperty("Bank_Account")]
        public StatisticsBankAccount BankAccount { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's combat.
        /// </summary>
        /// <see cref="StatisticsCombat"/>
        [JsonProperty("Combat")]
        public StatisticsCombat Combat { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's crimes.
        /// </summary>
        /// <see cref="Startup.StatisticsCrime"/>
        [JsonProperty("Crime")]
        public StatisticsCrime StatisticsCrime { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's smuggling.
        /// </summary>
        /// <see cref="StatisticsSmuggling"/>
        [JsonProperty("Smuggling")]
        public StatisticsSmuggling Smuggling { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's trading.
        /// </summary>
        /// <see cref="StatisticsTrading"/>
        [JsonProperty("Trading")]
        public StatisticsTrading Trading { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's mining.
        /// </summary>
        /// <see cref="StatisticsMining"/>
        [JsonProperty("Mining")]
        public StatisticsMining Mining { get; internal set; }

        /// <summary>
        /// Contains statistics on the commander's exploration.
        /// </summary>
        /// <see cref="StatisticsExploration"/>
        [JsonProperty("Exploration")]
        public StatisticsExploration Exploration { get; internal set; }
        
        /// <summary>
        /// Contains statistics on the commander's passenger missions.
        /// </summary>
        /// <see cref="StatisticsPassengers"/>
        [JsonProperty("Passengers")]
        public StatisticsPassengers Passengers { get; internal set; }

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

        
    }
}