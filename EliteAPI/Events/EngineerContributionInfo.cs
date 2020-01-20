using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class EngineerContributionInfo : EventBase
    {
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

        internal static EngineerContributionInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeEngineerContributionEvent(JsonConvert.DeserializeObject<EngineerContributionInfo>(json, JsonSettings.Settings));
        }
    }
}