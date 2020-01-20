using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class Mining
    {
        [JsonProperty("Mining_Profits")]
        public long MiningProfits { get; internal set; }
        [JsonProperty("Quantity_Mined")]
        public long QuantityMined { get; internal set; }
        [JsonProperty("Materials_Collected")]
        public long MaterialsCollected { get; internal set; }
    }
}