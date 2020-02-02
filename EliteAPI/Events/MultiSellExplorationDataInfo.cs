using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class MultiSellExplorationDataInfo : EventBase
    {
        [JsonProperty("Discovered")]
        public List<Discovered> Discovered { get; internal set; }

        [JsonProperty("BaseValue")]
        public long BaseValue { get; internal set; }

        [JsonProperty("Bonus")]
        public long Bonus { get; internal set; }

        [JsonProperty("TotalEarnings")]
        public long TotalEarnings { get; internal set; }

        internal static MultiSellExplorationDataInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMultiSellExplorationDataEvent(JsonConvert.DeserializeObject<MultiSellExplorationDataInfo>(json, JsonSettings.Settings));
        }
    }
}