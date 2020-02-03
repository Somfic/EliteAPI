using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// Holds statistics on the commander's mining.
    /// </summary>
    /// <see cref="StatisticsInfo"/>
    public class MiningInfo
    {
        internal MiningInfo() { }

        /// <summary>
        /// The total amount of profit made while mining.
        /// </summary>
        [JsonProperty("Mining_Profits")]
        public long MiningProfits { get; internal set; }

        /// <summary>
        /// The total amount of resources mined.
        /// </summary>
        [JsonProperty("Quantity_Mined")]
        public int QuantityMined { get; internal set; }

        /// <summary>
        /// The total amount of materials collected.
        /// </summary>
        [JsonProperty("Materials_Collected")]
        public int MaterialsCollected { get; internal set; }
    }
}