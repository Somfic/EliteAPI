using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class MaterialTraderStats
    {
        [JsonProperty("Trades_Completed")]
        public long TradesCompleted { get; internal set; }
        [JsonProperty("Materials_Traded")]
        public long MaterialsTraded { get; internal set; }
        [JsonProperty("Encoded_Materials_Traded")]
        public long EncodedMaterialsTraded { get; internal set; }
        [JsonProperty("Raw_Materials_Traded")]
        public long RawMaterialsTraded { get; internal set; }
        [JsonProperty("Grade_1_Materials_Traded")]
        public long Grade1_MaterialsTraded { get; internal set; }
        [JsonProperty("Grade_2_Materials_Traded")]
        public long Grade2_MaterialsTraded { get; internal set; }
        [JsonProperty("Grade_3_Materials_Traded")]
        public long Grade3_MaterialsTraded { get; internal set; }
        [JsonProperty("Grade_4_Materials_Traded")]
        public long Grade4_MaterialsTraded { get; internal set; }
        [JsonProperty("Grade_5_Materials_Traded")]
        public long Grade5_MaterialsTraded { get; internal set; }
    }
}