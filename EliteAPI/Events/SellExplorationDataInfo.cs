using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class SellExplorationDataInfo : EventBase
    {
        [JsonProperty("Systems")]
        public List<string> Systems { get; internal set; }

        [JsonProperty("Discovered")]
        public List<string> Discovered { get; internal set; }

        [JsonProperty("BaseValue")]
        public long BaseValue { get; internal set; }

        [JsonProperty("Bonus")]
        public long Bonus { get; internal set; }

        [JsonProperty("TotalEarnings")]
        public long TotalEarnings { get; internal set; }

        internal static SellExplorationDataInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeSellExplorationDataEvent(JsonConvert.DeserializeObject<SellExplorationDataInfo>(json, JsonSettings.Settings));
        }
    }
}