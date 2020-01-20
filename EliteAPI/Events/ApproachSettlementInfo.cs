using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ApproachSettlementInfo : EventBase
    {
        internal static ApproachSettlementInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeApproachSettlementEvent(JsonConvert.DeserializeObject<ApproachSettlementInfo>(json, JsonSettings.Settings));

        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("Latitude")]
        public double Latitude { get; internal set; }
        [JsonProperty("Longitude")]
        public double Longitude { get; internal set; }
    }
}
