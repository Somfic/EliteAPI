using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class EngineerContributionEvent : EventBase
    {
        internal EngineerContributionEvent() { }

        public static EngineerContributionEvent FromJson(string json) => JsonConvert.DeserializeObject<EngineerContributionEvent>(json);


        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }

        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Material")]
        public string Material { get; internal set; }

        [JsonProperty("Quantity")]
        public long Quantity { get; internal set; }

        [JsonProperty("TotalQuantity")]
        public long TotalQuantity { get; internal set; }

        
    }
}